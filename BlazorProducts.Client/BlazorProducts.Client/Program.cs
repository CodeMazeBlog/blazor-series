using Blazored.LocalStorage;
using BlazorProducts.Client.AuthProviders;
using BlazorProducts.Client.HttpRepository;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace BlazorProducts.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped(sp => new HttpClient 
			{ 
				BaseAddress = new Uri("https://localhost:5011/api/") 
			}
			.EnableIntercept(sp));
			
			builder.Services.AddScoped<IProductHttpRepository, ProductHttpRepository>();
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
