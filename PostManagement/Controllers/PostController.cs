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
                p.CreatedDate = DateTime.Now;
                p.UpdatedDate = DateTime.Now;
                context.Posts.Add(p);
                await context.SaveChangesAsync();
                await signalRHub.Clients.All.SendAsync("LoadProducts");
            }
            else
            {
                var postOld = context.Posts.FirstOrDefault(x => x.PostId == p.PostId);
                p.CreatedDate = postOld.CreatedDate;
                p.UpdatedDate = DateTime.Now;
                context.Posts.Update(p);
                await context.SaveChangesAsync();
                await signalRHub.Clients.All.SendAsync("LoadProducts");
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
