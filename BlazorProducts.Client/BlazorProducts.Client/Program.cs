using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using BlazorProducts.Client.HttpRepository;
using Tewr.Blazor.FileReader;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorProducts.Client.AuthProviders;
using Blazored.LocalStorage;
using BlazorProducts.Client.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace BlazorProducts.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("app");

			builder.Services.AddScoped(sp => new HttpClient 
			{ 
				BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
			}
			.EnableIntercept(sp));

			builder.Services.AddScoped<IProductHttpRepository, ProductHttpRepository>();
			builder.Services.AddFileReaderService(o => o.UseWasmSharedBuffer = true);
			builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
			builder.Services.AddScoped<RefreshTokenService>();
			builder.Services.AddHttpClientInterceptor();

			builder.Services.AddBlazoredLocalStorage();
			builder.Services.AddAuthorizationCore();
			builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
			builder.Services.AddScoped<HttpInterceptorService>();

			await builder.Build().RunAsync();
		}
	}
}
