using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechTestMVC.Areas.Identity.Data;

namespace TechTestMVC.Controllers
{
    [Authorize(Roles ="Admin,Staff")]
    public class AdminController : Controller
    {
        private UserManager<TechTestMVCUser> userManager;
        private IPasswordHasher<TechTestMVCUser> passwordHasher;

        public AdminController(UserManager<TechTestMVCUser> usrMgr, IPasswordHasher<TechTestMVCUser> passwordHash)
        {
            userManager = usrMgr;
            passwordHasher = passwordHash;
        }

        public IActionResult Index()
        {
            
            if (User.IsInRole("Admin"))
            {
                //var users = userManager.Users.Where(usr => usr.Role == "Staff");
                //return View(users);
                return View(userManager.Users);
            }
            else if(User.IsInRole("Staff"))
            {
                var users = userManager.Users.Where(usr => usr.Role == "Customer");
                return View(users);
            }

            return View(null);

        }

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(TechTestMVCUser user)
        {
            if (ModelState.IsValid)
            {
                TechTestMVCUser appUser = new TechTestMVCUser
                {
                    
                    UserName = user.Email,
                    Email = user.Email,
                    PasswordHash = user.PasswordHash,
                    Role = user.Role,
                    EmailConfirmed = true,
                    
                    
                };

                IdentityResult result = await userManager.CreateAsync(appUser, user.PasswordHash);
                IdentityResult result2 = await userManager.AddToRoleAsync(appUser, user.Role);
                if (result.Succeeded && result2.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }

        public async Task<IActionResult> Update(string id)
        {
            TechTestMVCUser user = await userManager.FindByIdAsync(id);
            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, string email, string password, string role)
        {
            TechTestMVCUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(email))
                    user.Email = email;
                else
                    ModelState.AddModelError("", "Email cannot be empty");

                if (!string.IsNullOrEmpty(password))
                    user.PasswordHash = passwordHasher.HashPassword(user, password);
                else
                    ModelState.AddModelError("", "Password cannot be empty");

                if (!string.IsNullOrEmpty(role))
                    user.Role = role;
                else
                    ModelState.AddModelError("", "Role cannot be empty");

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(role))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    IdentityResult result2 = await userManager.AddToRoleAsync(user, role);
                    if (result.Succeeded && result2.Succeeded)
                        return RedirectToAction("Index");
                    else
                        Errors(result);
                }
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View(user);
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            TechTestMVCUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("Index", userManager.Users);
        }
    }
}