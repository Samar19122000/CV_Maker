using SamarApp.Models;
using System.Collections.Generic;

namespace SamarApp.BL.Interfaces
{
    public interface ISlider
    {
        List<TbSlider> Getall();

        TbSlider GetUserById(int id);

        bool Add(TbSlider tbSlider);

        bool Edit(TbSlider tbSlider);

        bool Delete(int id);

    }
}
