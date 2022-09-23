using SamarApp.BL.Interfaces;
using SamarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SamarApp.BL
{
    public class CLSwork : IWork
    {
        public PersonalAppdbContext _Context { get; }

        public CLSwork(PersonalAppdbContext context)
        {
            _Context=context;
        }
       
        public bool Add(TbWork tbWork)
        {
            try
            {
                _Context.Add<TbWork>(tbWork);
                _Context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                TbWork tbWork = (TbWork)_Context.TbWorks.Where(a => a.Id == id).FirstOrDefault();
                _Context.TbWorks.Remove(tbWork);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                throw;
            }
        }

        public bool Edit(TbWork tbWork)
        {
          try
            {
                _Context.Entry(tbWork).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _Context.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                throw;
            }
        }

        public List<TbWork> Getall()
        {
            List<TbWork> tbWork = _Context.TbWorks.OrderByDescending(N => N.Id).ToList();

            return tbWork;
        }

        public TbWork GetUserById(int id)
        {
            TbWork tbWork = _Context.TbWorks.FirstOrDefault(a => a.Id == id);
            return tbWork;

        }
    }
}
