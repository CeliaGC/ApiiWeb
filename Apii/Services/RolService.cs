
using Apii.IServices;
using Entities.Entities;
using Logic.ILogic;
using Logic.Logic;

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

        public void DeleteRol(int Id)
        {
            _rolLogic.DeleteRol(Id);
        }

        public void UpdateRol(UserRol userRol)
        {
            _rolLogic.UpdateRol(userRol);
        }


        List<UserRol> IRolService.GetRolByCriteria(int IdRol)
        {
            return _rolLogic.GetRolByCriteria(IdRol);
        }

        List<UserRol> IRolService.GetAll()
        {
            return _rolLogic.GetAll();
        }
    }
}
