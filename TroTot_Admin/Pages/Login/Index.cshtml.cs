using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return Page();
            }
            else
            {
                return Redirect("/Login/Login");
            }
        }

 
        [BindProperty]
        public InputModel Input { get; set; }



        [TempData]
        public string ErrorMessage { get; set; }

       
        public class InputModel
        {

            [Required]
            [MinLength(8, ErrorMessage = ("Please enter again (min length 8) ! "))]
            public string UserName { get; set; }


            [Required]
            [MinLength(8, ErrorMessage = ("Please enter again (min length 8) ! "))]
            [DataType(DataType.Password)]
            public string Password { get; set; }

        }
        public IList<User> User { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()

        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            User = await _context.User.ToListAsync();

            User users = User.FirstOrDefault(user => user.username == Input.UserName);
            if (users!=null && BCrypt.Net.BCrypt.Verify(Input.Password, users.password))
            {

                if(users.role_id == 0)
                {
                    HttpContext.Session.SetString("UserName", Input.UserName);
                    ModelState.AddModelError(String.Empty, "true");
                    return RedirectToPage("/Account/Index");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Account is not admin");

                    return Page();
                }

            }

            ModelState.AddModelError(String.Empty, "User Name or Password not correct");

            return Page();
        }
    }
}