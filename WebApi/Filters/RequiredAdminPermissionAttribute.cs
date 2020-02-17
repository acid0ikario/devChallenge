
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;

using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Filters
{
    public class RequiredAdminPermissionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            TokenManipulations _token = new TokenManipulations(context.HttpContext.Request);
            if (!_token.IsAdminUser())
            {
               context.Result = new UnauthorizedObjectResult("Debe ser administrador para poder ejecutar esta accion");
            }
           
        }
    }
}
