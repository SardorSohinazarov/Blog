using Blog.MVC.Models;
using System.Text.Json;

namespace Blog.MVC.Repository
{
    public class PostFileRepository : IPostRepository
    {
        public Post Delete(int id)
        {
            var posts = Read();
            var removingPost = posts.FirstOrDefault(x => x.Id == id);
            posts.Remove(removingPost);
            Write(posts);
            return removingPost;
        }

        public Post Get(int id)
        {
            var posts = Read();
            var updatingPost = posts.FirstOrDefault(x => x.Id == id);
            updatingPost.Views += 1;
            Write(posts);
            return updatingPost;
        }

        public List<Post> Get()
        {
            var stringPosts = File.ReadAllText("Data\\PostsDemo.json");
            var posts = JsonSerializer.Deserialize<List<Post>>(stringPosts);
            return posts.ToList();
        }

        public Post Update(int id, Post post)
        {
            var posts = Read();
            var updatingPost = posts.FirstOrDefault(x => x.Id ==id);
            updatingPost = post;
            Write(posts);
            return post;
        }

        Post IPostRepository.Create(Post post)
        {
            var posts = Read();
            posts.Add(post);
            Write(posts);
            return post;
        }

        public List<Post> Read()
        {
            var stringPosts = File.ReadAllText("Data\\PostsDemo.json");
            var posts = JsonSerializer.Deserialize<List<Post>>(stringPosts);
            return posts.ToList();
        }
        
        public void Write(List<Post> posts)
        {
            var stringposts = JsonSerializer.Serialize<List<Post>>(posts);
            File.WriteAllText("Data\\PostsDemo.json",stringposts);
        }
    }
}
