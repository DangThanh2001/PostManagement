using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PostManagement.DataAccess;
using PostManagement.Hubs;
using PostManagement.Models;

namespace PostManagement.Controllers
{
    public class PostController : Controller
    {
        private readonly PostManagementDB context;
        private readonly IHubContext<SignalrServer> signalRHub;

        public PostController(PostManagementDB context, IHubContext<SignalrServer> signalRHub)
        {
            this.context = context;
            this.signalRHub = signalRHub;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> add(Post p)
        {
            if (p.PostId == 0)
            {
                context.Posts.Add(p);
                await context.SaveChangesAsync();
                await signalRHub.Clients.All.SendAsync("LoadProducts");
            }
            else
            {
                context.Posts.Update(p);
                await context.SaveChangesAsync();
                await signalRHub.Clients.All.SendAsync("LoadProducts");
            }
            return View("/Views/Home/Index.cshtml", context
                .Posts
                .Include(x => x.postCategory)
                .Include(x => x.appUser)
                .ToList());
        }

    }
}
