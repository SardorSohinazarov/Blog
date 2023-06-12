using Blog.MVC.Data;
using Blog.MVC.Models;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace Blog.MVC.Repository
{
    public class VideoFileRepository : IVideoRepository
    {
        public List<Video> Get()
        {
            var stringVideos = File.ReadAllText("Data\\VideosDemo.json");
            var videos = JsonSerializer.Deserialize<List<Video>>(stringVideos);
            return videos.Reverse<Video>().ToList();
        }
    }
}
