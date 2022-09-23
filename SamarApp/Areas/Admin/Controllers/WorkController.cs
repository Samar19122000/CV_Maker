using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamarApp.BL.Interfaces;
using SamarApp.Models;
using System;

namespace SamarApp.Areas.Admin.Controllers
{

    [Authorize]
    [Area("Admin")]
    public class WorkController : Controller
    {
        public IWork _Work { get; }

        public WorkController(IWork work)
        {
            _Work=work;
        }

        public IActionResult MyWork()
        {
            return View(_Work.Getall());
        }


        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                return View(_Work.GetUserById(Convert.ToInt32(id)));

            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public IActionResult Save(TbWork tbWork)
        {
            if (ModelState.IsValid)
            {
                if(tbWork.Id == 0 || tbWork.Id == null)
                {
                    _Work.Add(tbWork);
                    return RedirectToAction("MyWork");
                }
                else
                {
                    _Work.Edit(tbWork);
                    return RedirectToAction("MyWork");
                }

               
            }
            else
            {
                return RedirectToAction("MyWork");
            }
        }


        public IActionResult Delete(int id)
        {
            _Work.Delete(id);
            return RedirectToAction("MyWork");
        }












    }
}
