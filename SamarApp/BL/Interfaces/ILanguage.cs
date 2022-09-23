using SamarApp.Models;
using System.Collections.Generic;

namespace SamarApp.BL.Interfaces
{
    public interface ILanguage
    {
        List<TbLanguage> Getall();

        TbLanguage GetUserById(int id);

        bool Add(TbLanguage tbLanguage);

        bool Edit(TbLanguage tbLanguage);

        bool Delete(int id);


    }
}
