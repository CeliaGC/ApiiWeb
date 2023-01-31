using Apii.IServices;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Apii.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolController : ControllerBase
    {
        private readonly ILogger<RolController> _logger;
        private readonly IRolService _rolService;
        public RolController(ILogger<RolController> logger, IRolService rolService)
        {
            _logger = logger;
            _rolService = rolService;
        }

        [HttpPost(Name = "InsertRol")]
        public int Post([FromBody] UserRol userRol)
        {
            return _rolService.InsertUserRol(userRol);
        }
    }
}