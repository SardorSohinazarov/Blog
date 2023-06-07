using Blog.MVC.Models;

namespace Blog.MVC.ViewModels
{
    public class BlogPostViewModel
    {
        public Post Post { get; set; }
        public int PrevId { get; set; }
        public int NextId { get; set; }
    }
}
