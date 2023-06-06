using Blog.MVC.Data;
using Blog.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.MVC.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDbContext _dbContext;

        public PostRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Post Delete(int id)
        {
            var post = _dbContext.Posts.FirstOrDefault(p => p.Id == id);

            if (post != null)
            {
                _dbContext.Posts.Remove(post);
                _dbContext.SaveChanges();
            }

            return post;
        }

        public Post Get(int id)
        {
            var post = _dbContext.Posts.FirstOrDefault(x => x.Id == id);
            return post;
        }

        public List<Post> Get()
            => _dbContext.Posts.ToList();

        public Post Update(int id, Post post)
        {
            var updatedPost = _dbContext.Posts.Attach(post);
            updatedPost.State = EntityState.Modified;
            _dbContext.SaveChanges();
            return post;
        }

        Post IPostRepository.Create(Post post)
        {
            var newPost = _dbContext.AddAsync(post);
            _dbContext.SaveChanges();
            return post;
        }
    }
}
