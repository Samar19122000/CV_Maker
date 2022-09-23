using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamarApp.BL.Interfaces;
using SamarApp.Models;
using System.Linq;

namespace SamarApp.Controllers
{

   
    public class HomeController : Controller
    {
        //public ISlider _slider { get; }
        //public IAboutme _Aboutme { get; }
        //public IWork _Work { get; }
        //public IEducation _Education { get; }
        //public ILanguage _Language { get; }
        //public IProject _Project { get; }

        //public HomeController(ISlider slider , IAboutme aboutme , IWork work , IEducation education , ILanguage language , IProject project)
        //{
        //   _slider = slider;
        //    _Aboutme=aboutme;
        //    _Work=work;
        //    _Education=education;
        //    _Language=language;
        //    _Project=project;
        //}

        //public IActionResult Index()
        //{
        //    SliderViewModel model = new SliderViewModel();
        //    model.slider = _slider.Getall();
        //    model.slider = model.slider.Take(1);
        //    model.abouteme = _Aboutme.Getall();
        //    model.abouteme = model.abouteme.Take(1);
        //    model.work = _Work.Getall();
        //    model.work = _Work.Getall();
        //    model.tbEducation = _Education.Getall();
        //    model.tbEducation = _Education.Getall();
        //    model.tbLanguage = _Language.Getall();
        //    model.tbLanguage = _Language.Getall();
        //    model.tbProjects = _Project.Getall();
        //    model.tbProjects = _Project.Getall();

        //   return View(model);
        //}


        public IActionResult Index()
        {
            return RedirectToAction("Login", "Account", new { area = "Admin" });
        }
    }
}
