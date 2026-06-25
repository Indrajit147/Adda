using System.ComponentModel.DataAnnotations;

namespace Adda.Data.Models
{
    public class Post
    {
        [Key] 
        public int Id { get; set; }
        public string Content { get; set; }
        public string? ImageUrl { get; set; }
        public int NrOfReports { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        //Foreign key to the User who created the post
        public int UserId { get; set; }

        //Navigation property to the User
        public User User { get; set; }
        public ICollection<Like> Likes { get; set; } = new List<Like>();
    }
}
