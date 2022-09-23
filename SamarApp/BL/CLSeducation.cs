using SamarApp.BL.Interfaces;
using SamarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SamarApp.BL
{
    public class CLSeducation : IEducation
    {
        public PersonalAppdbContext _Context { get; }
        public CLSeducation(PersonalAppdbContext context)
        {
            _Context=context;
        }



        public bool Add(TbEducation tbEducation)
        {
            try
            {
                _Context.Add<TbEducation>(tbEducation);
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
                TbEducation tbEducation = (TbEducation)_Context.TbEducations.Where(a => a.Id == id).FirstOrDefault();
                _Context.TbEducations.Remove(tbEducation);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception )
            {

                throw;
            }
        }

        public bool Edit(TbEducation tbEducation)
        {
            try
            {
                _Context.Entry(tbEducation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _Context.SaveChanges();
                return true;

            }
            catch (Exception )
            {
                throw;
            }
        }

        public List<TbEducation> Getall()
        {
            List<TbEducation> tbEducation = _Context.TbEducations.OrderByDescending(a => a.Id).ToList();

            return tbEducation;
        }

        public TbEducation GetUserById(int id)
        {
            TbEducation tbEducation = _Context.TbEducations.FirstOrDefault(a => a.Id == id);
            return tbEducation;
        }
    }
}
