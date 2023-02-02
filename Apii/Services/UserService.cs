
using Apii.IServices;
using Data;
using Entities.Entities;
using Logic.ILogic;

namespace Apii.Services
{
    public class UserService : IUserService
    {
        private readonly IUserLogic _userLogic;
        public UserService(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }
        public int InsertUser(UserItem userItem)
        {
            _userLogic.InsertUserItem(userItem);
            return userItem.Id;
        }

        public void DeleteUser(int Id)
        {
            _userLogic.DeleteUser(Id);
         
        }

        void IUserService.UpdateUser(UserItem userItem)
        {
            _userLogic.UpdateUser(userItem);
        }

        List<UserItem> IUserService.GetUserByCriteria(int Id)
        {
            return _userLogic.GetUserByCriteria(Id);
            
        }

        List<UserItem> IUserService.GetAll()
        {
            return _userLogic.GetAll();
        }
    }
}