using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class BlogContoller:Controller
    {
        public IActionResult CreatorPage()
        {
            return View();
        }
    }
}
