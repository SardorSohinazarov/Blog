namespace Blog.MVC.Models
{
    public class MockPostRepository : IPostRepository
    {
        private readonly List<Post> _posts;

        public MockPostRepository()
        {
            _posts = new List<Post>()
            {
                new Post { Id = 1, Title = "1 post", Author = "Sardor" ,Content = "qale", Description = "siyosat haqida"},
                new Post { Id = 2, Title = "2 post", Author = "Sardor" ,Content = "qale", Description = "siyosat haqida"},
                new Post { Id = 3, Title = "3 post", Author = "Sardor" ,Content = "qale", Description = "siyosat haqida"},
                new Post { Id = 4, Title = "4 post", Author = "Sardor" ,Content = "qale", Description = "siyosat haqida"},
                new Post { Id = 5, Title = "5 post", Author = "Sardor" ,Content = "qale", Description = "siyosat haqida"},
                new Post { Id = 6, Title = "6 post", Author = "Sardor" ,Content = "qale", Description = "siyosat haqida"},
                new Post { Id = 7, Title = "7 post", Author = "Sardor" ,Content = "qale", Description = "siyosat haqida"},
            };
        }

        public void Create(Post post)
        {
            _posts.Add(post);
        }

        public Post Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Post Get(int id)
        {
            return _posts.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<Post> Get()
        {
            return _posts;
        }

        public Post Update(int id, Post post)
        {
            throw new NotImplementedException();
        }
    }
}
