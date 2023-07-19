using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace authentication.Data
{
  public class AuthDataContext : IdentityDbContext 
  {
    public AuthDataContext(DbContextOptions options) : base(options)
    {

    }
  }
}