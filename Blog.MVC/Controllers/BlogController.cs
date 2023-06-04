using Blog.MVC.Models;
using Blog.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.Controllers
{
    public class BlogController : Controller
    {
        private IPostRepository _postRepository;

        public BlogController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IActionResult Index() 
        {
            BlogPostsViewModel blogPostsViewModel = new BlogPostsViewModel()
            {
                Posts = _postRepository.Get()
            };

            return View(blogPostsViewModel);
        }
    }
}
