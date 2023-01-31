using Apii.IServices;
using Data;
using Entities.Entities;
using Logic.ILogic;

namespace Apii.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly ISecurityLogic _securityLogic;
        public SecurityService(ISecurityLogic securityLogic)
        {
            _securityLogic= securityLogic;
        }
        public bool ValidateUserCredentials(string userName, string userPassWord, int IdRol, int Id)
        {
           return _securityLogic.ValidateUserCredentials(userName, userPassWord, IdRol, Id) ;
        }
    }
}