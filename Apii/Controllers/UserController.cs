
using Apii.IServices;
using Apii.Services;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace Apii.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public int Post([FromBody] UserItem userItem)
        {
            return _userService.InsertUser(userItem);
        }

        [HttpDelete(Name = "DeleteUser")]
        public void Delete([FromQuery] string userName, [FromQuery] string userPassword, [FromQuery] int IdRol, [FromQuery] int Id)
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
    }
}