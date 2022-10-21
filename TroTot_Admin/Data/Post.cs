using System;
using System.Collections.Generic;

namespace TroTot_Admin.Data
{
    public partial class Post
    {
        public Post()
        {
            PostDetails = new HashSet<PostDetail>();
        }

        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int Price { get; set; }
        public string Address { get; set; } = null!;
        public string Poster { get; set; } = null!;
        public bool Type { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<PostDetail> PostDetails { get; set; }
    }
}
