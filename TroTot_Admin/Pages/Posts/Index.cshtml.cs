using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TroTot_Admin.Infrastructure;
using TroTot_Admin.Model;

namespace TroTot_Admin.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _db;
        public IEnumerable<Post> Posts { get; set; }

        public IndexModel(DataContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Posts = _db.Post;
        }
    }
}
