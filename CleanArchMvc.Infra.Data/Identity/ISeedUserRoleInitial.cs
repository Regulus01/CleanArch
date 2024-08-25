using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchMvc.Infra.Data.Identity;

public class SeedUserRoleInitial : ISeedUserRoleInitial
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> signInManager)
    {
        _userManager = userManager;
        _roleManager = signInManager;
    }
    
    public void SeedUsers()
    {
        if (_userManager.FindByEmailAsync("usuario@localhost").Result == null)
        {
            var user = new ApplicationUser();
            
            user.Email = "usuario@localhost";
            user.UserName = "usuario@localhost";
            user.NormalizedEmail = "USUARIO@LOCALHOST";
            user.NormalizedUserName = "USUARIO@LOCALHOST";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();
            
            var result = _userManager.CreateAsync(user, "Numsey#2021").Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "User").Wait();
            }
        }
        
        if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
        {
            var user = new ApplicationUser();
            
            user.Email = "admin@localhost";
            user.UserName = "admin@localhost";
            user.NormalizedEmail = "ADMIN@LOCALHOST";
            user.NormalizedUserName = "ADMIN@LOCALHOST";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();
            
            var result = _userManager.CreateAsync(user, "Numsey#2021").Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }

    public void SeedRoles()
    {
        if (!_roleManager.RoleExistsAsync("User").Result)
        {
            var role = new IdentityRole()
            {
                Name = "User", 
                NormalizedName = "USER"
            };

            _ =_roleManager.CreateAsync(role).Result;
        }
        
        if (!_roleManager.RoleExistsAsync("Admin").Result)
        {
            var role = new IdentityRole()
            {
                Name = "Admin", 
                NormalizedName = "ADMIN"
            };

            _ =_roleManager.CreateAsync(role).Result;
        }
    }
}