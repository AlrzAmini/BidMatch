using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

namespace BidMatch.Infrastructure.Authentication;

public static class ClaimsPrincipalExtensions
{
    public static Guid? GetUserId(this ClaimsPrincipal user)
    {
        var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
        return userIdClaim != null ? Guid.Parse(userIdClaim.Value) : null;
    }

    public static string? GetIdentityId(this ClaimsPrincipal user)
    {
        var identityIdClaim = user.FindFirst(JwtRegisteredClaimNames.Sub);
        return identityIdClaim?.Value;
    }
}