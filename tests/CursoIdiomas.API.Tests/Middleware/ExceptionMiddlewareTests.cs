using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using CursoIdiomas.API.Middleware;
using Microsoft.AspNetCore.Builder;
using System.Net;

namespace CursoIdiomas.API.Tests.Middleware
{
    public class ExceptionMiddlewareTests
    {
        [Fact]
        public async void ShouldReturnInternalServerError()
        {
            using var host = await new HostBuilder()
            .ConfigureWebHost(webBuilder =>
            {
                webBuilder
                    .UseTestServer()
                    .ConfigureServices(services =>
                    {
                        //services.AddMyServices();
                    })
                    .Configure(app =>
                    {
                        
                        app.UseMiddleware<ExceptionMiddleware>();

                        
                    });
            })
            .StartAsync();

            var response = await host.GetTestClient().GetAsync("/");

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [Fact]
        public async void NotShouldReturnInternalServerError()
        {
            using var host = await new HostBuilder()
           .ConfigureWebHost(webBuilder =>
           {
               webBuilder
                   .UseTestServer()
                   .ConfigureServices(services =>
                   {
                        //services.AddMyServices();
                    })
                   .Configure(app =>
                   {
                       app.UseMiddleware<ExceptionMiddleware>();
                   });
           })
           .StartAsync();

            var response = await host.GetTestClient().GetAsync("/");

            Assert.NotEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }
    }
}
