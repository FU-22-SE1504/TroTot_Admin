using System;
using System.Collections.Generic;

namespace TroTot_Admin.Data
{
    public partial class User
    {
        public User()
        {
            Posts = new HashSet<Post>();
            Profiles = new HashSet<Profile>();
            Reports = new HashSet<Report>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
