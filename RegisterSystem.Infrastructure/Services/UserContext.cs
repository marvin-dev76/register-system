using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using RegisterSystem.Application.Common.Interfaces;

namespace RegisterSystem.Infrastructure.Services
{
  public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
  {
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public string? GetEmail()
    {
      return _httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.Email);
    }

    public string? GetUserId()
    {
      return _httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
  }
}