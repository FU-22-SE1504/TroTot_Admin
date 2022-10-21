using System;
using System.Collections.Generic;

namespace TroTot_Admin.Data
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public int PostDetailId { get; set; }

        public virtual PostDetail PostDetail { get; set; } = null!;
    }
}
