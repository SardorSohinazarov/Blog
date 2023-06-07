using Blog.MVC.Models;
using Blog.MVC.Repository;
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
            BlogIndexViewModel blogPostsViewModel = new BlogIndexViewModel()
            {
                Posts = _postRepository.Get()
            };

            return View(blogPostsViewModel);
        }

        public IActionResult Posts(int? id)
        {
            BlogPostViewModel blogPostViewModel = new BlogPostViewModel()
            {
                Post = _postRepository.Get(id ?? 1),
                PrevId = 3,
                NextId = 3
            };

            return View(blogPostViewModel);
        }

        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(Post post)
        {
            if(ModelState.IsValid)
            {
                var newPost = _postRepository.Create(post);
                return RedirectToAction("posts", new { id = newPost.Id });
            }

            return View();
        }

        public IActionResult DeletePost(int id)
        {
            _postRepository.Delete(id);
            return RedirectToAction("index");
        }

        public IActionResult UpdatePost(int id)
        {
            var post = _postRepository.Get(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult UpdatePost(Post post)
        {
            if (ModelState.IsValid)
            {
                var newPost = _postRepository.Update(post.Id,post);
                return RedirectToAction("posts", new { id = newPost.Id });
            }
            return View();
        }
    }
}
