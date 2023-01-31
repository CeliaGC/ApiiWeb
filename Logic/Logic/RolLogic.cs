using Data;
using Entities.Entities;
using Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class RolLogic : BaseContextLogic, IRolLogic
    {
        public RolLogic(ServiceContext serviceContext) : base(serviceContext) { }
        public void InsertUserRol(UserRol userRol)
        {
            _serviceContext.Add(userRol);
            _serviceContext.SaveChanges();
        }

        void IRolLogic.DeleteRol(int Id)
        {
            {
                _serviceContext.RolType.Remove(_serviceContext.Set<UserRol>().Where(r => r.IdRol == Id).FirstOrDefault());
                _serviceContext.SaveChanges();
            }
        }
    }
}

