using Apii.IServices;
using Apii.Services;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Collections.Specialized;
using System.Security.Authentication;

namespace Apii.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
   
        public ProductController(ISecurityService securityService, IProductService productService, IUserService userService)
        {
            _productService = productService;
            _securityService = securityService;
            _userService = userService;
        }

        [HttpPost(Name = "InsertProduct")]
        public int Post([FromBody] ProductItem productItem)
        {
            return _productService.InsertProduct(productItem);
        }

        [HttpDelete(Name = "DeleteProduct")]
        public void Delete([FromQuery] string userName, [FromQuery] string userPassword, [FromQuery] int IdRol, [FromQuery] int Id)
        {
            var validCredentials = _securityService.ValidateUserCredentials(userName, userPassword, 1, Id);
            if (validCredentials == true)
            {
                _productService.DeleteProduct(Id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

    }
}
