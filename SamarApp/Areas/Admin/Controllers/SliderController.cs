using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamarApp.BL;
using SamarApp.BL.Interfaces;
using SamarApp.Models;
using System;

namespace SamarApp.Areas.Admin.Controllers
{

    [Authorize]
    [Area("Admin")]
    public class SliderController : Controller
    {
       public ISlider _slider { get; }
        public SliderController(ISlider slider)
        {
            _slider = slider;

        }
        public IActionResult MySlider()
        { 
            return View(_slider.Getall());
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                return View(_slider.GetUserById(Convert.ToInt32(id)));
            }
            else
            {
                return View();
            }


        }

        [HttpPost]
        public IActionResult Save(TbSlider tbSlider)
        {

            if (ModelState.IsValid)
            { 
                if (tbSlider.Id == 0 || tbSlider.Id == null)
                {
                    _slider.Add(tbSlider);
                    return RedirectToAction("MySlider");
                }
                else
                {
                    _slider.Edit(tbSlider);
                    return RedirectToAction("MySlider");
                }

            }
            else
            {
                return View("MySlider");
            }


        }

        public IActionResult Delete(int id)
        {
            _slider.Delete(id);
            return RedirectToAction("MySlider");
        }


    }
}
