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
            {
                _serviceContext.Users.Remove(_serviceContext.Set<UserItem>().Where(user => user.Id == Id).First());
                _serviceContext.SaveChanges();
            }
        }
    }
}
