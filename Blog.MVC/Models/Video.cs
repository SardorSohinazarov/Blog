using System.ComponentModel.DataAnnotations;

namespace Blog.MVC.Models
{
    public class Video
    {
        public int Id { get; set; }
        [Required]
        public string CreatedDate { get; set; }
        [Required]
        [Display(Name = "Title")]
        [MaxLength(15, ErrorMessage = "Exceeded maximum length of 15 characters.")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Picture Link")]
        public string PictureLink { get; set; }
        [Required]
        [Display(Name = "Video Link")]
        public string VideoLink { get; set; }
    }
}
