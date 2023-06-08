using Blog.MVC.Data;
using Blog.MVC.Models;

namespace Blog.MVC.Repository
{
    public class VideoRepository : IVideoRepository
    {
        private readonly BlogDbContext _blogDbContext;

        public VideoRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        public Video Create(Video video)
        {
            throw new NotImplementedException();
        }

        public Video Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Video> Get()
        {
            var videos =  _blogDbContext.Videos.ToList();
            return videos.Reverse<Video>().ToList();
        }

        public Video Update(int id, Video video)
        {
            throw new NotImplementedException();
        }
    }
}
