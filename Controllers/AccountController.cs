using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using MVC_Project_eng_ayman.Models;
using MVC_Project_eng_ayman.ViewModel;
using System.Security.Claims;

namespace MVC_Project_eng_ayman.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {

        public IActionResult Register()
        {
            return View(); //show form
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User() { Name=model.Name,Age=model.Age,Password=model.Password,Email=model.Email};
                ITIContext db = new ITIContext();
                db.Users.Add(user);
                db.SaveChanges();
                var role=db.Roles.FirstOrDefault(a=>a.Name=="Students");
                user.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            //add user in database
            return View();
        }
        public IActionResult Login()
        {
            return View(); //show form
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVIewModel model)
        {
            ITIContext db = new ITIContext();
            var result = db.Users.Include(a=>a.Roles).FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);
            if (result == null)
            {
                ModelState.AddModelError("", "username and password invalid");
                return View(model);
            }
            //claim
            Claim c1 = new Claim(ClaimTypes.Name, result.Name);
           
            Claim c2 = new Claim(ClaimTypes.Email, result.Email);
            List<Claim> Roleclaims = new List<Claim>();
            foreach(var item in result.Roles)
            {
                Roleclaims.Add(new Claim(ClaimTypes.Role, item.Name));
            }


            ClaimsIdentity ci = new ClaimsIdentity("Cookies");
            ci.AddClaim(c1);
            ci.AddClaim(c2);
            foreach(var item in Roleclaims)
            {
                ci.AddClaim(item);
            }
            ClaimsPrincipal cp = new ClaimsPrincipal();
            cp.AddIdentity(ci);

            await HttpContext.SignInAsync(cp);
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public async Task <IActionResult >LogOut()
        {
          await   HttpContext.SignOutAsync();
          return RedirectToAction("Index", "Home");
        }
    }
}

