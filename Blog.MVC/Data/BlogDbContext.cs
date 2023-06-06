using Blog.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.MVC.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) 
            :base(options)
        {}

        public DbSet<Post> Posts { get; set; }
    }
}
