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
using AutoMapper;
using WebApi.Filters;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class InventoryController : ControllerBase
    {

        private readonly IInventoryRepository _Inventory;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public InventoryController(IConfiguration config, IInventoryRepository inventory,  IMapper mapper)
        {
            _Inventory = inventory;
            _configuration = config;
            _mapper = mapper;
        }

        // GET api/values
        [HttpGet("GetListItems")]
        public ActionResult<IEnumerable<string>> GetListItems(int sku = 0)
        {
            return Ok(_Inventory.GetlistaItems(sku));
        }

        [HttpGet("GetAvalibleSku")]
        public ActionResult<IEnumerable<string>> GetAvalibleSku()
        {
            return Ok(_Inventory.GetAvalibleSkus());
        } 

        // GET api/values
        [RequiredAdminPermission]
        [ValidateModel]
        [HttpPost("addItem")]
        public ActionResult<IEnumerable<string>> addItem([FromBody] ItemsDTO pItem)
        {
            Items objItem = _mapper.Map<Items>(pItem);
            Items returnedItem = _Inventory.CreateItem(objItem);
            return Ok(returnedItem);

        }

        [RequiredAdminPermission]
        [ValidateModel]
        [HttpPost("UpdateItem")]
        public ActionResult<IEnumerable<string>> UpdateItem([FromBody] ItemsDTO pItem)
        {
            Items objItem = _mapper.Map<Items>(pItem);
            Items returnedItem = _Inventory.UpdateItem(objItem);
            return Ok(returnedItem);
          
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetListaInventario()
        {
            string secretKey = _configuration.GetValue<string>("DevSecretKey");
            var re = Request;
            var header = Request.Headers.First(x => x.Key == "Authorization");
            return Ok("");
        }

    }
}