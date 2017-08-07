using Microsoft.Owin;
using Owin;
using NoGuardianLeftBehind;

namespace NoGuardianLeftBehind
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}