using System.ComponentModel.DataAnnotations;

namespace TroTot_Admin.Model
{
    public class Post
    {
        [Key]
        public int post_id { get; set; }
        [Required]
        public int user_id { get; set; }
        [Required]
        public string title { get; set; }
        public string description { get; set; }
        [Required]
        public int price { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string poster { get; set; }
        [Required]
        public bool type { get; set; }
    }
}
