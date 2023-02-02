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
    public class UserLogic : BaseContextLogic, IUserLogic
    {
        public UserLogic(ServiceContext serviceContext) : base(serviceContext) { }
        public void InsertUserItem(UserItem userItem)
        {
            _serviceContext.Users.Add(userItem);
            _serviceContext.SaveChanges();
        }

        void IUserLogic.DeleteUser(int Id)
        {
            
            _serviceContext.Users.Remove(_serviceContext.Set<UserItem>().Where(user => user.Id == Id).First());
            _serviceContext.SaveChanges();
            
        }

        List<UserItem> IUserLogic.GetAll()
        {
            var userlist = _serviceContext.Users.ToList();
            return userlist; 
        }

        List<UserItem> IUserLogic.GetUserByCriteria(int Id)
        {
            var listuser = new UserItem();
            listuser.Id = Id;

            var resultList = _serviceContext.Set<UserItem>()
                                .Where(u => u.Id == Id);

            if (listuser.Id == Id)
            {
                resultList = resultList.Where(u => u.Id == Id);
            }


            return resultList.ToList();
        }

        void IUserLogic.UpdateUser(UserItem userItem)
        {
            _serviceContext.Users.Update(userItem);
            _serviceContext.SaveChanges();
        }
    }
}
