using System.ComponentModel.DataAnnotations;

namespace TroTot_Admin.Model
{
    public class Role
    {
        [Key]
        public int role_id { get; set; }
        [Required]
        public string role_name { get; set; }
        //public ICollection<User> Users { get; set; }
    }
}
