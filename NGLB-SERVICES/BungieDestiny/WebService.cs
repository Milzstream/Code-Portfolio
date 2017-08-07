using System;
using RestSharp;
using System.Linq;
using System.Reflection;

namespace BungieDestiny
{
    internal class WebService
    {
        //class variables
        private RestClient _client;
        private readonly string _apiKey;

        public WebService(string apiKey)
        {
            //Store Key
            _apiKey = apiKey;
        }

        /// <summary>
        ///     Execute Get Request Returning Deserilized Type
        /// </summary>
        /// <typeparam name="T">Type of Response</typeparam>
        /// <returns>Response Type</returns>
        public T Request<T>(object service, string methodName, object model = null) where T : new()
        {
            //Variables 
            var request = SetupRequest(service, methodName, model);

            return _client.Execute<T>(request).Data;
        }

        /// <summary>
        ///     Updates Rest API Segments
        /// </summary>
        /// <returns></returns>
        private RestRequest SetupRequest(object service, string methodName, object model)
        {
            //Variables
            var methodRoute = service.GetType()
                .GetMethod(methodName)
                .GetCustomAttributes(typeof(RouteAttribute), false)
                .FirstOrDefault() as RouteAttribute;

            var classRoute = service.GetType()
                .GetCustomAttributes(typeof(RouteAttribute), false)
                .FirstOrDefault() as RouteAttribute;

            var modelType = model.GetType();

            //Check Null
            if (methodRoute == null || classRoute == null)
            {
                throw new ArgumentNullException(methodRoute == null ? nameof(methodRoute) : nameof(classRoute));
            }

            var request = new RestRequest(methodRoute.Route, methodRoute.Method);

            //Set Client
            _client = new RestClient(classRoute.Route);

            //Header
            request.AddHeader("X-API-Key", _apiKey);

            //Loop through segment pairs
            foreach (var property in modelType.GetProperties())
            {
                //Variables
                var propertyName = property.Name;
                var propertyValue = property.GetValue(model).ToString();

                if (methodRoute.Method == Method.POST)
                {
                    request.AddQueryParameter(propertyName, propertyValue);
                }
                else
                {
                    request.AddUrlSegment(propertyName, propertyValue);
                }
            }

            return request;
        }
    }
}
