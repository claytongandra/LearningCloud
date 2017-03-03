using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using LearningCloud.MVC;

[assembly: OwinStartup(typeof(Startup))]

namespace LearningCloud.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
