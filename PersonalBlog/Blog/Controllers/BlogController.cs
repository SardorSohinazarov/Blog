using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult CreatorPage()
        {
            return View();
        }
    }
}
