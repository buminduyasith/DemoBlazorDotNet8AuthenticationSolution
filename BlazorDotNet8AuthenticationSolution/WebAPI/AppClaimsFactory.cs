using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

public class AppClaimsFactory : IUserClaimsPrincipalFactory<IdentityUser>
{
    public Task<ClaimsPrincipal> CreateAsync(IdentityUser user)
    {

        var claims = new Claim[] {
          new Claim(ClaimTypes.Email, user.Email ?? ""),
          new Claim(ClaimTypes.Name, user.Email),
          new Claim(ClaimTypes.NameIdentifier, user.Id),
          new Claim(ClaimTypes.Authentication, "true"),
          new Claim("TenantId", "123"), // <--- Here
        };
        var claimsIdentity = new ClaimsIdentity(claims, "Bearer");

        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        return Task.FromResult(claimsPrincipal);

    }
}