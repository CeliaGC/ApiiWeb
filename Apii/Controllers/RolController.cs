using Apii.IServices;
using Apii.Services;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace Apii.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IRolService _rolService;
        public RolController(ISecurityService securityService, IRolService rolService)
        {
           _securityService= securityService;
            _rolService = rolService;
        }

        [HttpPost(Name = "InsertRol")]
        public int Post([FromBody] UserRol userRol)
        {
            return _rolService.InsertUserRol(userRol);
        }

        [HttpDelete(Name = "DeleteRol")]
        public void Delete([FromQuery] string userName, [FromQuery] string userPassword, [FromQuery] int idRol, [FromQuery] int Id)
        {
            var validCredentials = _securityService.ValidateUserCredentials(userName, userPassword, 1);

            if (validCredentials == true)
            {
                _rolService.DeleteRol(Id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }
    }
}