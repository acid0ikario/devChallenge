﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _account;
        private readonly IConfiguration _configuration;

        public AccountController(IAccountRepository account, IConfiguration config )
        {
            _account = account;
            _configuration = config;
        }

        
        [HttpPost("Authenticate")]
        public IActionResult Authenticate ([FromBody] Users usuario)
        {
            Users objUsuario = _account.AuthenticateUser(usuario.userId, usuario.password);
            if (objUsuario != null)
            {
                return BuildToken(objUsuario);
            }
            return Unauthorized("Usuario o contraseñas incorrectas");
        }

        [HttpGet]
        public ActionResult<IEnumerable<Users>> Get()
        {
           return Ok(_account.GetListaUsers());
        }

        private IActionResult BuildToken(Users user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.userId),
                new Claim("rolId", user.rolId)
            };

            string secretKey = _configuration.GetValue<string>("DevSecretKey");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddDays(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "pgs30.com",
               audience: "pgs30.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration
            });

        }
    }
}