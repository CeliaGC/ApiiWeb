
using Apii.IServices;
using Entities.Entities;
using Logic.ILogic;

namespace Apii.Services
{
    public class RolService : IRolService
    {
        private readonly IRolLogic _rolLogic;
        public RolService(IRolLogic rolLogic)
        {
            _rolLogic = rolLogic;
        }
        public int InsertUserRol(UserRol userRol)
        {
            _rolLogic.InsertUserRol(userRol);
            return userRol.IdRol;
        }
    }
}
