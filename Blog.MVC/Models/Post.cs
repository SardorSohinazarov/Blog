namespace Blog.MVC.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; }
        public string AuthorUrl { get; set; } = "https://www.linkedin.com/in/sardorsohinazarov/";
        public string Content { get; set; }
        public string CreatedDate { get; set; } = DateTime.Now.ToString("dd MMMM, yyyy");
        public int Views { get; set; }
    }
}
