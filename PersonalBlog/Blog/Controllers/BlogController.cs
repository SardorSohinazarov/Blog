using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        static List<string> Posts = new List<string>();
        public IActionResult Index()
        {
            return View("Index",Posts);
        }
        
        public IActionResult CreatorPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatorPage(string content)
        {
            Posts.Add(content);
            return RedirectToAction("Index");
        }
    }
}
