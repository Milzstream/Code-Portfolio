using System.Runtime.CompilerServices;
using BungieDestiny.Models;

namespace BungieDestiny
{
    public abstract class BungieService
    {
        private readonly WebService _service;

        protected BungieService(string apiKey)
        {
            _service = new WebService(apiKey);
        }

        protected T Request<T>(object model = null, [CallerMemberName] string methodName = null)
        {
            var response = _service.Request<Message<T>>(this, methodName, model);
            return response.Response;
        }
    }
}
