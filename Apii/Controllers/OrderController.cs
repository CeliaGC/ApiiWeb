using Apii.IServices;
using Apii.Services;
using Data;
using Entities;
using Entities.Entities;
using Entities.OrderRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Collections.Specialized;
using System.Security.Authentication;

namespace Apii.Controllers
{
    [ApiController]

    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly ServiceContext _serviceContext;
        private readonly IOrderService _orderService;

        public OrderController(ISecurityService securityService, IProductService productService, IUserService userService, ServiceContext serviceContext, IOrderService orderService)
        {
            _productService = productService;
            _securityService = securityService;
            _userService = userService;
            _serviceContext = serviceContext;
            _orderService = orderService;
        }

        [HttpPost(Name = "InsertOrder")]
        public int Post([FromQuery] newOrderRequest newOrderRequest)
        {
            return _orderService.InsertOrder(newOrderRequest);
        }

        [HttpDelete(Name = "DeleteOrder")]
        public void Delete([FromQuery] string userName, [FromQuery] string userPassword, [FromQuery] int Id)
        {
            var validCredentials = _securityService.ValidateUserCredentials(userName, userPassword, 1);

            if (validCredentials == true)
            {
                _orderService.DeleteOrder(Id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModifyOrder")]
        public void Patch([FromQuery] string userName,
                          [FromQuery] string userPassword,
                          [FromBody] OrderItem orderItem)

        {
            var validCredentials = _securityService.ValidateUserCredentials(userName, userPassword, 1);
            if (validCredentials == true)
            {
                _orderService.UpdateOrder(orderItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "GetOrderByProduct")]
        public List<OrderItem> GetOrderByProduct([FromQuery] int IdProduct)
        {

            return _orderService.GetOrderByProduct(IdProduct);
        }

        [HttpGet(Name = "GetAllOrders")]
        public List<OrderItem> GetAllOrders()
        {

            return _orderService.GetAllOrders();
        }

        [HttpGet(Name = "GetOrderByUser")]
        public List<OrderItem> GetOrderByUser(int IdUser) 
        {
            return _orderService.GetOrderByUser(IdUser);
        }



    }
}