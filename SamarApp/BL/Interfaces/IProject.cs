using SamarApp.Models;
using System.Collections.Generic;

namespace SamarApp.BL.Interfaces
{
    public interface IProject
    {
        List<TbProject> Getall();

        TbProject GetUserById(int id);

        bool Add(TbProject tbProject);

        bool Edit(TbProject tbProject);

        bool Delete(int id);

    }
}
