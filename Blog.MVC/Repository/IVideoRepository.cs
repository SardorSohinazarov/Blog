using Blog.MVC.Models;

namespace Blog.MVC.Repository
{
    public interface IVideoRepository
    {
        public List<Video> Get();
    }
}
