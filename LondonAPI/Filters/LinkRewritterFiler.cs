using LondonAPI.Infrastructure;
using LondonAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection;

namespace LondonAPI.Filters
{
    public class LinkRewritterFiler : IAsyncResultFilter
    {
        // inject url helper factory to generate helper urls on the fly
        private readonly IUrlHelperFactory _urlhelper;
        public LinkRewritterFiler(IUrlHelperFactory urlhelper)
        {
            _urlhelper = urlhelper;

        }
        public Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {

            var asObjectResult = context.Result as ObjectResult;

            bool SkipValid = asObjectResult?.StatusCode > 400 || asObjectResult?.Value == null || asObjectResult?.Value as Resource == null;

            if (SkipValid)
            {
                next();
            }
            var rewritter = new LinkRewritter(_urlhelper.GetUrlHelper(context));

            // use reflection and find any links ahed 
            RewriteAllLinks(asObjectResult, rewritter);
            return next();
        }

        private void RewriteAllLinks(Object model, LinkRewritter rewritter)
        {

            if (model == null) return;

            return;

            //var allProperties = model.GetType().GetTypeInfo().GetAllProperties();


        }
    }
}
