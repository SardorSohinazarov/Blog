using Blog.MVC.Models;

namespace Blog.MVC.Repository
{
    public interface IVideoRepository
    {
        public List<Video> Get();
        public Video Create(Video video);
        public Video Update(int id, Video video);
        public Video Delete(int id);
    }
}
