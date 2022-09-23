using SamarApp.Models;
using System.Collections.Generic;

namespace SamarApp.BL.Interfaces
{
    public interface IEducation
    {

        List<TbEducation> Getall();

        TbEducation GetUserById(int id);

        bool Add(TbEducation tbEducation);

        bool Edit(TbEducation tbEducation);

        bool Delete(int id);


    }
}
