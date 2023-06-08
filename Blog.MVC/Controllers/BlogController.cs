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
            var ids = _postRepository.Get().Select(x => x.Id).ToList();

            var prev = 0;
            var next = 0;

            if(id == ids[0])
            {
                prev = ids[0];
            }
            else
            {
                prev = ids.Where(x => ids.IndexOf(x) + 1 == ids.IndexOf(id??1) && ids.IndexOf(x) + 1 < ids.Count).First();
            }

            if(id == ids[ids.Count-1])
            {
                next = ids[ids.Count-1];
            }
            else
            {
                next = ids.Where(x => ids.IndexOf(x) - 1 == ids.IndexOf(id??1) && ids.IndexOf(x) - 1 >= 0).First();
            }

            

            BlogPostViewModel blogPostViewModel = new BlogPostViewModel()
            {
                PrevId = prev,
                Post = _postRepository.Get(id ?? 1),
                NextId = next
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
