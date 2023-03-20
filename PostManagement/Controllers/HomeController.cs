using Microsoft.AspNetCore.Mvc;
using PostManagement.DataAccess;
using PostManagement.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Microsoft.AspNetCore.SignalR;
using PostManagement.Hubs;

namespace PostManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PostManagementDB context;
        private readonly IHubContext<SignalrServer> signalRHub;
        private string searchStr { get; set; }

        public HomeController(ILogger<HomeController> logger, PostManagementDB contex,
            IHubContext<SignalrServer> signalRHub)
        {
            this.context = contex;
            _logger = logger;
            this.signalRHub = signalRHub;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var res = context.Posts.Include(x => x.postCategory)
                .Include(x => x.appUser).ToList();
            searchStr = Search.Instance().StringSearch;
            if (searchStr != null)
            {
                res = context.Posts.Include(x => x.postCategory)
               .Include(x => x.appUser)
               .Where(x => 
                    x.Title.ToLower().Contains(searchStr.ToLower()) || 
                    x.Content.ToLower().Contains(searchStr.ToLower()) ||
                    x.PostId.ToString().ToLower().Contains(searchStr.ToLower()) 
                    )
               .ToList();
            }
            return Ok(res);
        }

        public async Task<IActionResult> Index(string search)
        {
            List<Post> listAllPost = await
                context
                .Posts
                .Include(x => x.postCategory)
                .Include(x => x.appUser)
                .ToListAsync();
            if (!string.IsNullOrEmpty(search))
            {
                listAllPost = listAllPost.Where(x => x.Title.ToLower().Contains(search.ToLower())
                || x.Content.ToLower().Contains(search.ToLower())
                ).ToList();
            }
            ViewBag.Search = search;
            await signalRHub.Clients.All.SendAsync("LoadProducts");
            Search.Instance().StringSearch = search;
            return View(listAllPost);
        }

        public IActionResult add()
        {
            Post p = new Post();
            p.CreatedDate = DateTime.Now;
            List<AppUser> listUser = context.AppUsers.ToList();
            List<PostCategory> listCat = context.PostCategories.ToList();
            ViewBag.listCat = listCat;
            ViewBag.listUser = listUser;
            return View("/Views/PostPage/Add.cshtml", p);
        }

        public IActionResult update(int? id)
        {
            Post p = context.Posts
                .Include(x => x.postCategory)
                .Include(x => x.appUser)
                .FirstOrDefault(x => x.PostId == id);
            List<AppUser> listUser = context.AppUsers.ToList();
            List<PostCategory> listCat = context.PostCategories.ToList();
            ViewBag.listUser = listUser;
            ViewBag.listCat = listCat;
            return View("/Views/PostPage/Add.cshtml", p);
        }

        public IActionResult detail(int? id)
        {
            Post p = context.Posts.FirstOrDefault(x => x.PostId == id);
            List<AppUser> listUser = context.AppUsers.ToList();
            List<PostCategory> listCat = context.PostCategories.ToList();
            ViewBag.listUser = listUser;
            ViewBag.listCat = listCat;
            return View("/Views/PostPage/Detail.cshtml", p);
        }

        public async Task<IActionResult> delete(int? id)
        {
            try
            {
                Post p = await context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
                context.Posts.Remove(p);
                await context.SaveChangesAsync();
                await signalRHub.Clients.All.SendAsync("LoadProducts");
                return View("/Views/Home/Index.cshtml", context
                .Posts
                .Include(x => x.postCategory)
                .Include(x => x.appUser)
                .ToList());
            }
            catch (Exception e)
            {

            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}