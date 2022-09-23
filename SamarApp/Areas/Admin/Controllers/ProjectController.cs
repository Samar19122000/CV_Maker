using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SamarApp.BL.Interfaces;
using SamarApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SamarApp.Areas.Admin.Controllers
{

    [Authorize]
    [Area("Admin")]
    public class ProjectController : Controller
    {
        public IProject _Project { get; }

        public ProjectController(IProject project)
        {
            _Project=project;
        }

     
        public IActionResult MyProjects()
        {
            return View(_Project.Getall());
        }


        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                return View(_Project.GetUserById(Convert.ToInt32(id)));

            }
            else
            {
                return View();
            }
        }



        public async Task<IActionResult> Save(TbProject tbProject, List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string PImage = Guid.NewGuid().ToString()+".jpg";
                        var FilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\ProjectUploads", PImage);
                        using (var Stream = System.IO.File.Create(FilePath))
                        {
                            await file.CopyToAsync(Stream);
                        }
                        tbProject.PImage = PImage;
                    }
                }
                if (tbProject.Id == 0 || tbProject.Id == null)
                {
                    _Project.Add(tbProject);
                    return RedirectToAction("MyProjects");
                }
                else
                {
                    _Project.Edit(tbProject);
                    return RedirectToAction("MyProjects");
                }
            }
            else
            {
                return View("MyProjects");
            }
        }


        public IActionResult Delete(int id)
        {
            _Project.Delete(id);
            return RedirectToAction("MyProjects");
        }




    }
}
