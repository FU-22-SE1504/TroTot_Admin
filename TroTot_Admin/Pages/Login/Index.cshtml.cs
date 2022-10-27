using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using System.ComponentModel.DataAnnotations;
using TroTot_Admin.Model;

namespace TroTot_Admin.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly TroTot_Admin.Infrastructure.DataContext _context;

        public IndexModel(TroTot_Admin.Infrastructure.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("UserName")==null)
            {
                return Page();
            }
            else
            {
                return Redirect("/Login/Login");
            }
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [MinLength(8, ErrorMessage = ("Please enter again (min length 8) ! "))]
            public string UserName { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [MinLength(8, ErrorMessage = ("Please enter again (min length 8) ! "))]
            [DataType(DataType.Password)]
            public string Password { get; set; }

        }
        public IList<User> User { get; set; } = default!;
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()

        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            User = await _context.User.ToListAsync();

            User users = User.FirstOrDefault(user => user.username == Input.UserName);
            if (BCrypt.Net.BCrypt.Verify( Input.Password, users.password))
            {
                HttpContext.Session.SetString("UserName", Input.UserName);
                ModelState.AddModelError(String.Empty, "true");
                return RedirectToPage("/Account/Index");
            }

            ModelState.AddModelError(String.Empty,users.password);

            return Page();
        }
    }
}
