using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IRolLogic
    {
        void InsertUserRol(UserRol userRol);
        void DeleteRol(int Id);
        void UpdateRol(UserRol userRol);

        List<UserRol> GetRolByCriteria(int IdRol);
        List<UserRol> GetAll();
    }

        
}
