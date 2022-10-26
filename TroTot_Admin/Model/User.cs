using System.ComponentModel.DataAnnotations;

namespace TroTot_Admin.Model
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string email { get; set; }
        public string? phone_number { get; set; }
        public string? full_name { get; set; }
        [Required]
        public DateTime create_at { get; set; }
        [Required]
        public int role_id { get; set; }
        public string avatar { get; set; }
    }
}
