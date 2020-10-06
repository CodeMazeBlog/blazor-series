using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProducts.Client.HttpRepository
{
	public class RefreshTokenService
	{
		private readonly AuthenticationStateProvider _authProvider;
		private readonly IAuthenticationService _authService;

		public RefreshTokenService(AuthenticationStateProvider authProvider, IAuthenticationService authService)
		{
			_authProvider = authProvider;
			_authService = authService;
		}

		public async Task<string> TryRefreshToken()
		{
			var authState = await _authProvider.GetAuthenticationStateAsync();
			var user = authState.User;

			var exp = user.FindFirst(c => c.Type.Equals("exp")).Value;
			var expTime = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(exp));

			var timeUTC = DateTime.UtcNow;

			var diff = expTime - timeUTC;
			if (diff.TotalMinutes <= 2)
				return await _authService.RefreshToken();

			return string.Empty;
		}
	}
}
