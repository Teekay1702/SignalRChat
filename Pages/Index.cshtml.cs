using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ChatDbContext _db;

    public IndexModel(ChatDbContext db)
    {
        _db = db;
    }

    public List<ChatMessage> Messages { get; set; }

    public async Task OnGetAsync()
    {
        Messages = await _db.Messages.ToListAsync();
    }
}
