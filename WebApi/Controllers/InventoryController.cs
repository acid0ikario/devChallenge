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
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
             string secretKey = _configuration.GetValue<string>("DevSecretKey");
            var re = Request;
            var header = Request.Headers.First(x => x.Key == "Authorization");
            return Ok(isAdminUser(header.Value, secretKey));
        }

        
    }
}