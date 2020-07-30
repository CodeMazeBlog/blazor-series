using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using BlazorProducts.Client.HttpRepository;
using Tewr.Blazor.FileReader;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorProducts.Client.AuthProviders;

namespace BlazorProducts.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IProductHttpRepository, ProductHttpRepository>();
            builder.Services.AddFileReaderService(o => o.UseWasmSharedBuffer = true);

            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, TestAuthStateProvider>();

            await builder.Build().RunAsync();
        }
    }
}
