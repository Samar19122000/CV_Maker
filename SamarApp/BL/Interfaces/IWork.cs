using SamarApp.Models;
using System.Collections.Generic;

namespace SamarApp.BL.Interfaces
{
    public interface IWork
    {

        List<TbWork> Getall();

        TbWork GetUserById(int id);

        bool Add(TbWork tbWork);

        bool Edit(TbWork tbWork);

        bool Delete(int id);
    }
}
