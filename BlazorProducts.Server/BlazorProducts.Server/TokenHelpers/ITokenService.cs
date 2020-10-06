using BlazorProducts.Server.Context;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorProducts.Server.TokenHelpers
{
	public interface ITokenService
	{
		SigningCredentials GetSigningCredentials();
		Task<List<Claim>> GetClaims(User user);
		JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims);
		string GenerateRefreshToken();
		ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
	}
}
