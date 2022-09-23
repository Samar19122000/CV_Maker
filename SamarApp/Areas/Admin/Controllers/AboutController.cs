using Microsoft.AspNetCore.Mvc;
using SamarApp.BL.Interfaces;
using SamarApp.Models;
using DAL;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SamarApp.Areas.Admin.Controllers
{

    [Authorize]
    [Area("Admin")]
    public class AboutController : Controller
    {
        public IAboutme _Aboutme { get; }
        public AboutController(IAboutme aboutme)
        {
            _Aboutme=aboutme;
        }  

        public IActionResult AboutInfo()
        {
            return View(_Aboutme.Getall());
        }


        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                return View(_Aboutme.GetUserById(Convert.ToInt32(id)));

            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async  Task<IActionResult> Save(TbAbouteme tbAbouteme,List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string Image = Guid.NewGuid().ToString()+".jpg";
                        var FilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\AboutApload", Image);
                        using (var Stream = System.IO.File.Create(FilePath))
                        {
                            await file.CopyToAsync(Stream);
                        }
                        tbAbouteme.Image = Image;
                    }
                }
                if (tbAbouteme.Id == 0 || tbAbouteme.Id == null)
                {
                    _Aboutme.Add(tbAbouteme);
                    return RedirectToAction("AboutInfo");
                }
                else
                {
                    _Aboutme.Edit(tbAbouteme);
                    return RedirectToAction("AboutInfo");
                }
            }
            else
            {
                return View("AboutInfo");
            }
        }


        public IActionResult Delete(int id)
        {
            _Aboutme.Delete(id);
            return RedirectToAction("AboutInfo");
        }



    }
}
