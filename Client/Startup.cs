using FluentAssertions.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;

namespace BlazorApp2.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
         
        }

        public void Configure(IComponentsApplicationBuilder app)
        {

            app.AddComponent<App>("app");
        }
    }
}
