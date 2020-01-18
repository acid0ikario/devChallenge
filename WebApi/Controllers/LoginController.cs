using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {


        private readonly ILoginRepositoty _login;

        public LoginController(ILoginRepositoty login)
        {
            _login = login;
        }

        // POST api/values
        [HttpPost]
        public void Post(string user, string password)
        {
           
        }

        [HttpGet]
        public ActionResult<IEnumerable<Users>> Get()
        {
           return Ok(_login.GetListaUsers());
        }
    }
}