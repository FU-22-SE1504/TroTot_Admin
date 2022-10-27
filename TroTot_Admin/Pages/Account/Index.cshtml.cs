using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroTot_Admin.Infrastructure;
using TroTot_Admin.Model;

namespace TroTot_Admin.Pages.Account
{
    public class IndexModel : PageModel
    {
        private readonly TroTot_Admin.Infrastructure.DataContext _context;

        public IndexModel(TroTot_Admin.Infrastructure.DataContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.User != null)
            {
                User = await _context.User.Include(P => P.Role).ToListAsync();
                //String decode = Encoding.UTF8.GetString(Convert.FromBase64CharArray(U))
            }
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }
    }
}
