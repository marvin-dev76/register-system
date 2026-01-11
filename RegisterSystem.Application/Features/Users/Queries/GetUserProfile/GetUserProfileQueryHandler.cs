using MediatR;
using Microsoft.AspNetCore.Identity;
using RegisterSystem.Application.Common.DTOs.User;
using RegisterSystem.Application.Common.Exceptions;
using RegisterSystem.Application.Common.Interfaces;
using RegisterSystem.Domain.Entities;

namespace RegisterSystem.Application.Features.Users.Queries.GetUserProfile
{
  public class GetUserProfileQueryHandler(
    UserManager<ApplicationUser> userManager,
    IUserContext userContext
    ) : IRequestHandler<GetUserProfileQuery, UserProfileDTO>
  {
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IUserContext _userContext = userContext;

    public async Task<UserProfileDTO> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    {
      var email = _userContext.GetEmail();
      if (string.IsNullOrWhiteSpace(email))
        throw new UnauthorizedAccessException();
      var user = await _userManager.FindByEmailAsync(email)
        ?? throw new EmailNotFoundException("User not found");

      return new UserProfileDTO(
        email,
        user.FullName
      );
    }
  }
}