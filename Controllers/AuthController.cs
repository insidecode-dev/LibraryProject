using LibraryProject.Models;
using LibraryProject.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly IRepository<AppUser> _appUserRepository;
        public AuthController(IRepository<AppUser> appUserRepository)
        {
            _appUserRepository = appUserRepository;            
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> LogInAsync(AppUser appUser)
		{            
            //we checked here if such user exists
            if (_appUserRepository.Any(user=>user.UserName==appUser.UserName && user.DataStatus!=Enums.DataStatus.Deleted))
            {
                AppUser selectedUser = _appUserRepository.Default(x=>x.UserName == appUser.UserName && x.DataStatus!=Enums.DataStatus.Deleted);
                bool verifyPassword = BCrypt.Net.BCrypt.Verify(appUser.Password,selectedUser.Password);
                if (verifyPassword) {

                    List<Claim> claims = new List<Claim> { 
                    new Claim( "username", selectedUser.UserName),
                    new Claim ( "userID", selectedUser.ID.ToString()),
                    new Claim ( "role", selectedUser.Role.ToString())
                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);//
                    if (selectedUser.Role==Enums.Role.admin)
                    {
                        return RedirectToAction("Index", "Home", new { area="Managment"});
                    }
                    else if (selectedUser.Role == Enums.Role.user)
                    {
                        //null indicates that page is going to no view 
                        return RedirectToAction("Index", "Home", null);
                    }
                }
            }
			return View();
		}


        public async Task<IActionResult> LogOutAsync()
        {

            await HttpContext.SignOutAsync();
            return RedirectToAction("LogIn");
        }
	}
}
