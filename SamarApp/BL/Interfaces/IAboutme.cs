using SamarApp.Models;
using System.Collections.Generic;

namespace SamarApp.BL.Interfaces
{
    public interface IAboutme
    {
        List<TbAbouteme> Getall();

        TbAbouteme GetUserById(int id);

        bool Add(TbAbouteme tbSlider);

        bool Edit(TbAbouteme tbSlider);

        bool Delete(int id);



    }
}
