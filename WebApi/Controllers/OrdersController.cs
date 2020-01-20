﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrdersController : ContollerSecureBase
    {

        private readonly IConfiguration _configuration;
        private readonly IOrdersRepository _orders;
        private readonly IInventoryRepository _inventory;
        public OrdersController(IOrdersRepository orders, IConfiguration config, IInventoryRepository inventory )
        {
            _orders = orders;
            _configuration = config;
            _inventory = inventory;

        }

        // GET api/values
        [HttpGet("GetListOrders")]

        public ActionResult<IEnumerable<string>> GetListOrders(string userId="")
        {
            return Ok(_orders.GetListaOrders(userId));
        }

        [HttpPost("createOrder")]
        public ActionResult<IEnumerable<string>> createOrder([FromBody] Orders order)
        {
            string secretKey = _configuration.GetValue<string>("DevSecretKey");
            order.userId = GetUsuarioToken(GetTokenAuth(Request), secretKey);
            int avalibleSotk = _inventory.GetStock(order.sku);
            if (avalibleSotk < order.qty)
            {
                return BadRequest("no hay suficiente items disponibles. Cantidad disponible: " + avalibleSotk.ToString());
            }

            return Ok(_orders.CreateOrder(order));
        }

        [HttpPost("cancelOrder")]
        public ActionResult<IEnumerable<string>> cancelOrder([FromBody] Orders order)
        {
            string secretKey = _configuration.GetValue<string>("DevSecretKey");
            string usuarioEjecuta = GetUsuarioToken(GetTokenAuth(Request), secretKey);
            if (usuarioEjecuta != order.userId || isAdminUser(GetTokenAuth(Request),secretKey) == false)
                return Unauthorized("Solo el usuario que realizo la orden o el administrador puede cancelar la orden");


            return Ok(_orders.CancelOrder(order));
        }
    }
}