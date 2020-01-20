using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Repository.Interfaces;
using WebApi.Helpers;
using Microsoft.Extensions.Configuration;
using DataAccess.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class InventoryController : ContollerSecureBase
    {

        private readonly IInventoryRepository _Inventory;
        private readonly IConfiguration _configuration;

        public InventoryController(IInventoryRepository inventory, IConfiguration config)
        {
            _Inventory = inventory;
            _configuration = config;


        }

        // GET api/values
        [HttpGet("GetListItems")]
        public ActionResult<IEnumerable<string>> GetListItems(int sku = 0)
        {
            return Ok(_Inventory.GetlistaItems(sku));
        }

        // GET api/values
        [HttpPost("addItem")]
        public ActionResult<IEnumerable<string>> addItem([FromBody] Items item)
        {
           
            string secretKey = _configuration.GetValue<string>("DevSecretKey");
            if (isAdminUser(GetTokenAuth(Request), secretKey))
            {
                Items returnedItem = _Inventory.CreateItem(item);
                return Ok(returnedItem);
            }

            return Unauthorized("No esta autorizado para realizar esta accion");
        }

        [HttpPost("UpdateItem")]
        public ActionResult<IEnumerable<string>> UpdateItem([FromBody] Items item)
        {

            string secretKey = _configuration.GetValue<string>("DevSecretKey");
            if (isAdminUser(GetTokenAuth(Request), secretKey))
            {
                Items returnedItem = _Inventory.UpdateItem(item);
                return Ok(returnedItem);
            }

            return Unauthorized("No esta autorizado para realizar esta accion");
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetListaInventario()
        {
            string secretKey = _configuration.GetValue<string>("DevSecretKey");
            var re = Request;
            var header = Request.Headers.First(x => x.Key == "Authorization");
            return Ok(isAdminUser(header.Value, secretKey));
        }

    }
}