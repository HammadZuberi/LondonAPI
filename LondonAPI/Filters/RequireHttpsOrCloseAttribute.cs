using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LondonAPI.Filters
{
    public class RequireHttpsOrCloseAttribute : RequireHttpsAttribute
    {
        protected override void HandleNonHttpsRequest(AuthorizationFilterContext filterContext)
        {// default behaivour to over ride
            //base.HandleNonHttpsRequest(filterContext);

            filterContext.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            filterContext.Result =  new StatusCodeResult(statusCode: StatusCodes.Status400BadRequest);
        }
    }
}
