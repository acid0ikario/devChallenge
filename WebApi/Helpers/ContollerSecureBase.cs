using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Helpers
{
    public abstract class ContollerSecureBase: ControllerBase
    {
       

        public bool isAdminUser(string token, string strkey)
        {
           
            var key = Encoding.ASCII.GetBytes(strkey);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
           
            var claims = handler.ValidateToken(token, validations, out var tokenSecure);

            if( claims.Claims.FirstOrDefault(x => x.Type == "rolId").Value == "ADM")
                return true;

            return false;
        }

        public string GetUsuarioToken(string token, string strkey)
        {

            var key = Encoding.ASCII.GetBytes(strkey);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            var claims = handler.ValidateToken(token, validations, out var tokenSecure);

            return claims.Identity.Name;
                
        }

        public string GetTokenAuth(HttpRequest re) {
            var header = Request.Headers.First(x => x.Key == "Authorization");
            string token = header.Value;
            token = token.Replace("Bearer ", "");
            return token;
        }

    }
}
