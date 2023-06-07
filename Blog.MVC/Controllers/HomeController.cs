using Blog.MVC.Models;
using Blog.MVC.Repository;
using Blog.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostRepository _postRepository;

        public HomeController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult About()
        {
            return View();
        }


        public IActionResult Videos()
        {
            BlogIndexViewModel blogPostsViewModel = new BlogIndexViewModel()
            {
                Posts = _postRepository.Get()
            };

            return View(blogPostsViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}