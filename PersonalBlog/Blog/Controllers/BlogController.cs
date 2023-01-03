using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using System.Linq;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        static List<BlogEntry> Posts = new List<BlogEntry>();
        public IActionResult Index()
        {
            return View("Index",Posts);
        }
        
        public IActionResult CreatorPage(Guid id)
        {
            if(id != Guid.Empty)
            {
                BlogEntry ExistingEntry = Posts.FirstOrDefault(x => x.Id == id);
                return View(model:ExistingEntry);
            }
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
