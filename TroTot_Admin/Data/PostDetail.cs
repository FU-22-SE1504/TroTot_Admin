using System;
using System.Collections.Generic;

namespace TroTot_Admin.Data
{
    public partial class PostDetail
    {
        public PostDetail()
        {
            Comments = new HashSet<Comment>();
        }

        public int PostDetailId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int Price { get; set; }
        public string Address { get; set; } = null!;
        public string Poster { get; set; } = null!;
        public string? ReviewImg { get; set; }

        public virtual Post Post { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
