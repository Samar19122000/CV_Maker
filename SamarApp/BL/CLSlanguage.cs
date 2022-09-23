using SamarApp.BL.Interfaces;
using SamarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SamarApp.BL
{
    public class CLSlanguage : ILanguage
    {

        public PersonalAppdbContext _Context { get; }
        public CLSlanguage(PersonalAppdbContext context)
        {
            _Context=context;
        }

        public bool Add(TbLanguage tbLanguage)
        {
            try
            {
                _Context.Add<TbLanguage>(tbLanguage);
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
                TbLanguage tbLanguage = (TbLanguage)_Context.TbLanguages.Where(a => a.Id == id).FirstOrDefault();
                _Context.TbLanguages.Remove(tbLanguage);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception )
            {

                throw;
            }
        }

        public bool Edit(TbLanguage tbLanguage)
        {
            try
            {
                _Context.Entry(tbLanguage).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _Context.SaveChanges();
                return true;

            }
            catch (Exception )
            {
                throw;
            }
        }


        public List<TbLanguage> Getall()
        {
            List<TbLanguage> TbLanguage = _Context.TbLanguages.OrderByDescending(a => a.Id).ToList();

            return TbLanguage;
        }

        public TbLanguage GetUserById(int id)
        {
            TbLanguage tbLanguage = _Context.TbLanguages.FirstOrDefault(a => a.Id == id);
            return tbLanguage;
        }
    }
}
