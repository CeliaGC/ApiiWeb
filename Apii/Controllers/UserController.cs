
using Apii.IServices;
using Apii.Services;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace Apii.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IUserService _userService;
        public UserController(ISecurityService securityService, IUserService userService)
        {
            _securityService= securityService;
            _userService = userService;
        }

        [HttpPost(Name = "InsertUser")]
        public int Post([FromQuery] string userName, [FromQuery] string userPassword, [FromBody] UserItem userItem)
        {
            var validCredentials = _securityService.ValidateUserCredentials(userName, userPassword, 1);
            if (validCredentials == true)
            {
                return _userService.InsertUser(userItem);
            }

            else
            {
                throw new InvalidCredentialException();
            }

        }

        [HttpDelete(Name = "DeleteUser")]
        public void Delete([FromQuery] string userName, [FromQuery] string userPassword, [FromQuery] int Id)
        {
            var validCredentials = _securityService.ValidateUserCredentials(userName, userPassword, 1);
            if (validCredentials == true)
            {
                _userService.DeleteUser(Id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModifyUser")]
        public void Patch([FromQuery] string userName,
                         [FromQuery] string userPassword,
                         [FromBody] UserItem userItem)

        {
            var validCredentials = _securityService.ValidateUserCredentials(userName, userPassword, 1);
            if (validCredentials == true)
            {
                _userService.UpdateUser(userItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetUserByCriteria")]
        public List<UserItem> GetProductByCriteria([FromQuery] string userName, [FromQuery] string userPassword, [FromQuery] int Id)
        {

            var validCredentials = _securityService.ValidateUserCredentials(userName, userPassword, 1);
            if (validCredentials == true)
            {

                return _userService.GetUserByCriteria(Id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetAllUsers")]
        public List<UserItem> GetAll([FromQuery] string userName, [FromQuery] string userPassword)
        {
            var validCredentials = _securityService.ValidateUserCredentials(userName, userPassword, 1);
            if (validCredentials == true)
            {

                return _userService.GetAll();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }
    }
}