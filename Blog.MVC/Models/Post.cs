using System.ComponentModel.DataAnnotations;

namespace Blog.MVC.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Main content")]
        public string Content { get; set; }
        [Required]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Display(Name = "Linkedin profile")]
        [RegularExpression("^(https?:\\/\\/)?(www\\.)?linkedin\\.com\\/(in|pub)\\/[a-zA-Z0-9-_]{5,30}\\/?$", ErrorMessage = "linkedin profile url is invalid")]
        public string AuthorUrl { get; set; } = "https://www.linkedin.com/in/sardorsohinazarov/";
        public string CreatedDate { get; set; } = DateTime.Now.ToString("dd MMMM, yyyy");
        public int Views { get; set; }
    }
}
