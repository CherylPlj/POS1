using POS1.Models;
using Microsoft.EntityFrameworkCore;
using POS1.Services;

var builder = WebApplication.CreateBuilder(args);

// Ecommerce service
builder.Services.AddHttpClient<EcommerceService>(client =>
{
    client.BaseAddress = new Uri("https://gizmodeecommerce.azurewebsites.net/"); // Replace with Ecommerce System URL
});


// Inventory service
builder.Services.AddHttpClient<InventoryService>(client =>
{
    client.BaseAddress = new Uri("https://gizmodeinventorysystem.azurewebsites.net/"); // Replace with Inventory System URL
});

// Add services to the container.
// Add Localizatiom - PH
builder.Services.AddLocalization();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowEcommerceSystem", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Add session services to the container
builder.Services.AddDistributedMemoryCache(); // Adds in-memory caching for session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout as per your requirement
    options.Cookie.HttpOnly = true; // Only accessible by the server
    options.Cookie.IsEssential = true; // Necessary for session management
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Login/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseRequestLocalization("en-PH");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();//
app.UseCors("AllowEcommerceSystem");

// Add session middleware to the request pipeline
app.UseSession(); // This should come before UseAuthorization

app.UseAuthorization();

// THIS IS THE ORIGINAL, BRING BACK THIS:
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=LoginPage}/{id?}");

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Sales}/{action=Sales}");




app.Run();
