using SamarApp.BL.Interfaces;
using SamarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SamarApp.BL
{
    public class CLSproject : IProject
    {
        public PersonalAppdbContext _Context { get; }
        public CLSproject(PersonalAppdbContext context)
        {
            _Context=context;
        }


        public bool Add(TbProject tbProject)
        {
            try
            {
                _Context.Add<TbProject>(tbProject);
                _Context.SaveChanges();
                return true;

            }
            catch (Exception )
            {
                throw;
            }
        }



        public bool Delete(int id)
        {
            try
            {
                TbProject tbProject = (TbProject)_Context.TbProjects.Where(a => a.Id == id).FirstOrDefault();
                _Context.TbProjects.Remove(tbProject);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception )
            {

                throw;
            }
        }

        public bool Edit(TbProject tbProject)
        {
            try
            {
                _Context.Entry(tbProject).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _Context.SaveChanges();
                return true;

            }
            catch (Exception )
            {
                throw;
            }
        }

        public List<TbProject> Getall()
        {
            List<TbProject> tbProject = _Context.TbProjects.OrderByDescending(a => a.Id).ToList();

            return tbProject;
        }

        public TbProject GetUserById(int id)
        {
            TbProject tbProject = _Context.TbProjects.FirstOrDefault(a => a.Id == id);
            return tbProject;
        }
    }
}
