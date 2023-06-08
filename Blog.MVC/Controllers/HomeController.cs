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
        private readonly IVideoRepository _videoRepository;

        public HomeController(
            IPostRepository postRepository, 
            IVideoRepository videoRepository)
        {
            _postRepository = postRepository;
            _videoRepository = videoRepository;
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
            HomeVideosViewModel homeVideosViewModel = new HomeVideosViewModel()
            {
                Videos = _videoRepository.Get()
            };

            return View(homeVideosViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}