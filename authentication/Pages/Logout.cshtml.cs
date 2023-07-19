using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace authentication.Pages
{
  public class LogoutModel : PageModel
  {
    private readonly SignInManager<IdentityUser> _signInManager;
    public LogoutModel(SignInManager<IdentityUser> signInManager)
    {
      _signInManager = signInManager;
    }

    public void OnGet()
    {
    }
    public IActionResult OnPostStayAsync()
    {
      return RedirectToPage("Index");
    }

    public async Task<IActionResult> OnPostLeaveAsync()
    {
      await _signInManager.SignOutAsync();
      return RedirectToPage("Login");
    }
  }
}