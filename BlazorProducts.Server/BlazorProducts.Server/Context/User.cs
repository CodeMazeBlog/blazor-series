using Microsoft.AspNetCore.Identity;
using System;

namespace BlazorProducts.Server.Context
{
	public class User : IdentityUser
	{
		public string RefreshToken { get; set; }
		public DateTime RefreshTokenExpiryTime { get; set; }
	}
}
