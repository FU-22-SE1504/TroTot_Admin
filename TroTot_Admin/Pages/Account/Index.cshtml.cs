using System;
using System.Collections.Generic;
using System.Linq;
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
                User = await _context.User.ToListAsync();
            }
        }
    }
}
