﻿using Blog.MVC.Models;
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
                Post = _postRepository.Get(id ?? 1)
            };
            return View(blogPostViewModel);
        }
    }
}
