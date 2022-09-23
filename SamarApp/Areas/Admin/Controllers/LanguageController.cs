using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamarApp.BL.Interfaces;
using SamarApp.Models;
using System;

namespace SamarApp.Areas.Admin.Controllers
{

    [Authorize]
    [Area("Admin")]
    public class LanguageController : Controller
    {
        public ILanguage _Language { get; }
        public LanguageController(ILanguage language)
        {
            _Language=language;
        }

        public IActionResult MyLanguages()
        {
            return View(_Language.Getall());
        }


        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                return View(_Language.GetUserById(Convert.ToInt32(id)));
            }
            else
            {
                return View();
            }

        }


        [HttpPost]
        public IActionResult Save(TbLanguage tbLanguage)
        {

            if (ModelState.IsValid)
            {
                if (tbLanguage.Id == 0 || tbLanguage.Id == null)
                {
                    _Language.Add(tbLanguage);
                    return RedirectToAction("MyLanguages");
                }
                else
                {
                    _Language.Edit(tbLanguage);
                    return RedirectToAction("MyLanguages");
                }

            }
            else
            {
                return View("MyLanguages");
            }

        }



        public IActionResult Delete(int id)
        {
            _Language.Delete(id);
            return RedirectToAction("MyLanguages");
        }







    }
}
