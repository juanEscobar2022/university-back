using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using UniversityFullstack.BL.Data;

namespace UniversityFullstack.API
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(UniversityContext.Create);
        }
    }
}
