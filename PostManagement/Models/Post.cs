using System.ComponentModel.DataAnnotations.Schema;

namespace PostManagement.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public AppUser appUser { get; set; }
        [Column("AuthorId")]
        public int AppUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int PublishStatus { get; set; }
        public PostCategory postCategory { get; set; }
        [Column("CategoryId")]
        public int PostCategoryId { get; set; }
    }
}
