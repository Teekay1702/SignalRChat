using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Security.Claims;

[Authorize] // Only logged-in users can send messages
public class ChatHub : Hub
{
    private readonly ChatDbContext _db;

    public ChatHub(ChatDbContext db)
    {
        _db = db;
    }

    public async Task SendMessage(string message)
    {
        var user = Context.User.Identity.Name;  // Get logged-in username
        var chatMessage = new ChatMessage { User = user, Message = message };

        _db.Messages.Add(chatMessage);
        await _db.SaveChangesAsync();

        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
