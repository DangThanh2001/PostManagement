using System.ComponentModel.DataAnnotations.Schema;

namespace PostManagement.Models
{
    public class PostCategory
    {
        [Column("CategoryId")]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}
