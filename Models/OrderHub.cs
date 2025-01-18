using Microsoft.AspNetCore.SignalR;
using POS1.Models;

public class OrderHub : Hub
{
    // Method to send real-time order data to clients
    public async Task SendRecentOrders(List<Order> orders)
    {
        await Clients.All.SendAsync("ReceiveRecentOrders", orders);
    }
}
