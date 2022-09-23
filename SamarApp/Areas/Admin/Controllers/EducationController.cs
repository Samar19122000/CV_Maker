using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamarApp.BL.Interfaces;
using SamarApp.Models;
using System;

namespace SamarApp.Areas.Admin.Controllers
{

    [Authorize]
    [Area("Admin")]
    public class EducationController : Controller
    {
        public IEducation _Education { get; }
        public EducationController(IEducation education)
        {
            _Education=education;
        }



        public IActionResult MyEducation()
        {
            return View(_Education.Getall());
        }


        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                return View(_Education.GetUserById(Convert.ToInt32(id)));
            }
            else
            {
                return View();
            }

        }


        [HttpPost]
        public IActionResult Save(TbEducation tbEducation)
        {

            if (ModelState.IsValid)
            {
                if (tbEducation.Id == 0 || tbEducation.Id == null)
                {
                    _Education.Add(tbEducation);
                    return RedirectToAction("MyEducation");
                }
                else
                {
                    _Education.Edit(tbEducation);
                    return RedirectToAction("MyEducation");
                }

            }
            else
            {
                return View("MyEducation");
            }

        }



        public IActionResult Delete(int id)
        {
            _Education.Delete(id);
            return RedirectToAction("MyEducation");
        }








    }
}
