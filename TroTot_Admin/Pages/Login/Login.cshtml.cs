using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TroTot_Admin.Model;

namespace TroTot_Admin.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly TroTot_Admin.Infrastructure.DataContext _context;

        public LoginModel(TroTot_Admin.Infrastructure.DataContext context)
        {
            _context = context;
        }
        public async Task OnGet()
        {
            HttpContext.Session.Clear();

        }
    }
}
