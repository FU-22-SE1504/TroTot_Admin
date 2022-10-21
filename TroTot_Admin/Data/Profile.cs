using System;
using System.Collections.Generic;

namespace TroTot_Admin.Data
{
    public partial class Profile
    {
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int? Phone { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
