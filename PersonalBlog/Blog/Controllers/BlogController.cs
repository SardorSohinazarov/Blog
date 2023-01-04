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
        public IActionResult CreatorPage(BlogEntry entry)
        {
            if(entry.Id == Guid.Empty)
            {
                //agar idsi yo'q bo'sa yangi yarat
                BlogEntry newEntry = new BlogEntry();
                newEntry.Content = entry.Content;
                newEntry.Id = Guid.NewGuid();
                Posts.Add(newEntry);
            }
            else
            {
                // oldindan bo'lsa edit qilib qo'y
                BlogEntry ExistingEntry = Posts.FirstOrDefault(x => x.Id == entry.Id);
                ExistingEntry.Content = entry.Content;
            }

            return RedirectToAction("Index");
        }
    }
}
