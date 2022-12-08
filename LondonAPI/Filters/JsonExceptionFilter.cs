using LondonAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.AspNetCore.Hosting;
namespace LondonAPI.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        public JsonExceptionFilter(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _env = env;

        }
        public void OnException(ExceptionContext context)
        {

            //for running in only in prod
            var error = new ApiError();
            if (_env.IsDevelopment())
            {

                error.ErrorMessage = context.Exception.Message;
                error.Details = context.Exception.StackTrace.ToString();

            }
            else
            {

                error.ErrorMessage = "Oops! something went wrong.";
                error.Details = context.Exception.Message;

            }            //return internal server error.

            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };


        }
    }
}
