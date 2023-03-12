using System.ComponentModel.DataAnnotations.Schema;

namespace PostManagement.Models
{
    public class AppUser
    {
        [Column("UserId")]
        public int Id { get; set; }
        public string FullName{ get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
