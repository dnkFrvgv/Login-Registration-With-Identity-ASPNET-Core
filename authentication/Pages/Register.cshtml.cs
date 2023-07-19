using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using authentication.Model;
using Microsoft.AspNetCore.Identity;

namespace authentication.Pages
{
  public class RegisterModel : PageModel
  {
    [BindProperty]
    public Register Model { get; set; }

    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
      _userManager = userManager;
      _signInManager = signInManager;
    }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (ModelState.IsValid)
      {
        var user = new IdentityUser() { UserName = Model.Name, Email = Model.Email };
        var saveUserToDb = await _userManager.CreateAsync(user, Model.Password);

        if (saveUserToDb.Succeeded)
        {
          await _signInManager.SignInAsync(user, false);
          return RedirectToPage("Index");
        }

        foreach (var err in saveUserToDb.Errors)
        {
          ModelState.AddModelError("", err.Description);

        }
      }

      return Page();

    }
  }
}