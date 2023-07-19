using authentication.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace authentication.Pages
{
  public class LoginModel : PageModel
  {

    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;


    [BindProperty]
    public Login Model { get; set; }
    public LoginModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
      _signInManager = signInManager;
      _userManager = userManager;
    }

    public async Task<IActionResult> OnPostAsync(string url = null)
    {
      if (ModelState.IsValid)
      {

        var user = await _userManager.FindByEmailAsync(Model.Email);

        if (user != null)
        {
          var login = await _signInManager.PasswordSignInAsync(user.UserName, Model.Password, false, false);

          if (login.Succeeded)
          {
            if (url == null || url == "/")
            {
              return RedirectToPage("Index");
            }
            else
            {
              return RedirectToPage(url);
            }
          }
        }

        ModelState.AddModelError("", "Email ou senha incorretos");
      }

      return Page();
    }
  }
}