using DesafioCarrefour.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCarrefour.WebApi.Setup;

public class AuthorizeAttibute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Items["User"] is not User)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized Access !!!" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
