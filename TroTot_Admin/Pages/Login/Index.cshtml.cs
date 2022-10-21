using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroTot_Admin.Data;

namespace TroTot_Admin.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly TroTot_Admin.Data.TroTotContext _context;

        public IndexModel(TroTot_Admin.Data.TroTotContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Users != null)
            {
                User = await _context.Users
                .Include(u => u.Role).ToListAsync();
            }
        }
    }
}
