using SamarApp.BL.Interfaces;
using SamarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SamarApp.BL   
{
    public class CLSslider:ISlider
    {
        private readonly PersonalAppdbContext _context;
        public CLSslider(PersonalAppdbContext context)
        {
           _context = context;  
        }


        public List<TbSlider> Getall()
        {
            List<TbSlider> sliderList = _context.TbSliders.OrderByDescending(a => a.Id).ToList();

            return sliderList;
        }


        public TbSlider GetUserById(int id)
        {
            TbSlider tbSlider = _context.TbSliders.FirstOrDefault(a => a.Id == id);
            return tbSlider;

        }

        public bool Add(TbSlider tbSlider)
        {
            try
            {
                _context.Add<TbSlider>(tbSlider);
                _context.SaveChanges();
                return true;

            }
            catch (Exception )
            {
                throw;
            }
        }


        public bool Edit(TbSlider tbSlider)
        {
            try
            {
                _context.Entry(tbSlider).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                TbSlider tbSlider = (TbSlider)_context.TbSliders.Where(a => a.Id == id).FirstOrDefault();
                _context.TbSliders.Remove(tbSlider);
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
