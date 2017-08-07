using System;
using RestSharp;

namespace BungieDestiny
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    internal partial class RouteAttribute : Attribute
    {
        public string Route { get; private set; }
        public Method Method { get; private set; }

        public RouteAttribute(string route, Method method = Method.GET)
        {
            Route = route;
            Method = method;
        }
    }
}
