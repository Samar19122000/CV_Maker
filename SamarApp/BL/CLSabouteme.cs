using SamarApp.Models;
using DAL;
using SamarApp.BL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SamarApp.BL
{
    public class CLSabouteme:IAboutme
    {

        private readonly PersonalAppdbContext _context ;
        public CLSabouteme(PersonalAppdbContext context)
        {
                _context = context;
        }


        public List<TbAbouteme> Getall()
        {
            List<TbAbouteme> tbAboutemes = _context.TbAboutemes.OrderByDescending(N => N.Id).ToList();

            return tbAboutemes;
        }

        public TbAbouteme GetUserById(int id)
        {
            TbAbouteme abouteme = _context.TbAboutemes.FirstOrDefault(t => t.Id == id);
            return abouteme;
        }

        public bool Add(TbAbouteme tbAbout)
        {
            try
            {
                _context.Add<TbAbouteme>(tbAbout);
                _context.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                throw;
            }
        }

        public bool Edit(TbAbouteme tbAbout)
        {
            try
            {
                _context.Entry(tbAbout).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
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
                TbAbouteme tbAbout = (TbAbouteme)_context.TbAboutemes.Where(a => a.Id == id).FirstOrDefault();
                _context.TbAboutemes.Remove(tbAbout);
                _context.SaveChanges();
                return true;
            }
            catch (Exception )
            {

                throw;
            }
        }


    }
}
