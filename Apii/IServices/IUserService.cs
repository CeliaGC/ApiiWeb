using Entities.Entities;

namespace Apii.IServices
{
    public interface IUserService
    {
        int InsertUser(UserItem userItem);
        void DeleteUser(int Id);
    }
}