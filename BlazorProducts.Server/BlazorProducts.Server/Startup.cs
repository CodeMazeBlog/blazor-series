using System.IO;
using System.Text;
using BlazorProducts.Server.Context;
using BlazorProducts.Server.Repository;
using BlazorProducts.Server.TokenHelpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace BlazorProducts.Server
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(policy =>
			{
				policy.AddPolicy("CorsPolicy", opt => opt
				.AllowAnyOrigin()
				.AllowAnyHeader()
				.AllowAnyMethod()
				.WithExposedHeaders("X-Pagination"));
			});

			services.AddDbContext<ProductContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("sqlConnection")));

			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<ITokenService, TokenService>();

			services.AddIdentity<User, IdentityRole>()
				.AddEntityFrameworkStores<ProductContext>();

			var jwtSettings = Configuration.GetSection("JwtSettings"); 
			services.AddAuthentication(opt => 
			{ 
				opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
				opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
			}).AddJwtBearer(options => 
			{ 
				options.TokenValidationParameters = new TokenValidationParameters 
				{ 
					ValidateIssuer = true, 
					ValidateAudience = true, 
					ValidateLifetime = true, 
					ValidateIssuerSigningKey = true, 
					
					ValidIssuer = jwtSettings.GetSection("validIssuer").Value, 
					ValidAudience = jwtSettings.GetSection("validAudience").Value, 
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("securityKey").Value)) 
				}; 
			});

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();
			app.UseCors("CorsPolicy");
			app.UseStaticFiles();
			app.UseStaticFiles(new StaticFileOptions()
			{
				FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
				RequestPath = new PathString("/StaticFiles")
			});

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
