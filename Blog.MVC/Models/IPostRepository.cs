namespace Blog.MVC.Models
{
    public interface IPostRepository
    {
        public Post Get(int id);
        public List<Post> Get();
        public Post Create(Post post);
        public Post Update(int id,Post post);
        public Post Delete(int id);
    }
}
