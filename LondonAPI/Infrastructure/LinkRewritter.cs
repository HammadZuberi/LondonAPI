using LondonAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LondonAPI.Infrastructure
{
    public class LinkRewritter
    {
        private readonly IUrlHelper _urlHelper;

        public LinkRewritter(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }


        public RootResponse Rewrite(RootResponse rootResponse)
        {
            if (rootResponse == null) return null;

            return new RootResponse
            {
                Href = _urlHelper.Link(rootResponse.RouteName, rootResponse.RouteValues),
                Methods = rootResponse.Methods,
                Releations = rootResponse.Releations
                };
        }

    }
}
