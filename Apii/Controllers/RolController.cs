using Apii.IServices;
using Apii.Services;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace Apii.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
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
        public int Post([FromQuery] string userName, [FromQuery] string userPassword, [FromBody] UserRol userRol)
        {
            var validCredentials = _securityService.ValidateUserCredentials(userName, userPassword, 1);

            if (validCredentials == true) 
            {
                return _rolService.InsertUserRol(userRol);
            }
            else
            {
                throw new InvalidCredentialException();
            }

        }

        [HttpDelete(Name = "DeleteRol")]
        public void Delete([FromQuery] string userName, [FromQuery] string userPassword, [FromQuery] int Id)
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

        [HttpPatch(Name = "ModifyRol")]
        public void Patch([FromQuery] string userName,
                  [FromQuery] string userPassword,
                  [FromBody] UserRol userRol)

        {
            var validCredentials = _securityService.ValidateUserCredentials(userName, userPassword, 1);
            if (validCredentials == true)
            {
                _rolService.UpdateRol(userRol);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetRolByCriteria")]
        public List<UserRol> GetRolByCriteria([FromQuery] int IdRol)
        {

            return _rolService.GetRolByCriteria(IdRol);
        }

        [HttpGet(Name = "GetAllRol")]
        public List<UserRol> GetAll()
        {

            return _rolService.GetAll();
        }

    }
}
