using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SamarApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SamarApp.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AdminsController : Controller
    {


        private readonly UserManager<ApplicationUser> _UserManager;

        public AdminsController(UserManager<ApplicationUser> userManager)
        {
            this._UserManager=userManager;
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Index(string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue))
            {
                return View(_UserManager.Users);
            }
            else
            {
                var user = await _UserManager.FindByEmailAsync(searchValue);

                return View(new List<ApplicationUser> { user });
            }
        }

        public async Task<IActionResult> Details(string id, string ViewName = "Details")
        {
            if (id == null)
                return NotFound();
            var user = await _UserManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();
            return View(ViewName, user);
        }

        public async Task<IActionResult> Edit(string id)
        {
            return await Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] string id, ApplicationUser updatedUser)
        {
            if (id != updatedUser.Id)
                return BadRequest();

            if (ModelState.IsValid)
                try
                {
                    var user = await _UserManager.FindByIdAsync(updatedUser.Id);
                   
                    user.UserName = updatedUser.UserName;
                    user.NormalizedUserName = updatedUser.UserName.ToUpper();
                    user.PhoneNumber = updatedUser.PhoneNumber;
                   
                    var result = await _UserManager.UpdateAsync(user);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    throw;
                }

            return View(updatedUser);
        }


        public async Task<IActionResult> Delete(string id)
        {
            return await Details(id, "Delete");
        }

        [HttpPost]

        public async Task<IActionResult> Delete([FromRoute] string id, ApplicationUser DeletedUser)
        {
            if (id != DeletedUser.Id)
                return BadRequest();
            try
            {

                var user = await _UserManager.FindByIdAsync(DeletedUser.Id);
               
                var result = await _UserManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction(nameof(Index));

                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);

                return View(DeletedUser);
            }
            catch (Exception)
            {
                throw;
            }


        }

    }
}
