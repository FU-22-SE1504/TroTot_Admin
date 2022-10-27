using System.ComponentModel.DataAnnotations;

namespace TroTot_Admin.Model
{
    public class User
    {
        [Key]
        [Display(Name = "ID")]
        public int user_id { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Username")]
        [StringLength(maximumLength: 20, MinimumLength = 8, ErrorMessage = "Username must be greater than 8 and lower than 20 character")]
        public string username { get; set; }
        [Required]
        [Display(Name = "Password")]

        public string password { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string email { get; set; }
        [Display(Name = "Phone Number")]

        public string? phone_number { get; set; }
        [Display(Name = "Full Name")]
        public string? full_name { get; set; }
        [Required]
        [Display(Name = "Date Created")]
        public DateTime create_at { get; set; }
        [Required]
        [Display(Name = "Role")]
        public int role_id { get; set; }
        public string avatar { get; set; }
    }
}
