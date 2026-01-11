using MediatR;
using RegisterSystem.Application.Common.DTOs.User;

namespace RegisterSystem.Application.Features.Users.Queries.GetUserProfile
{
  public record GetUserProfileQuery() : IRequest<UserProfileDTO>;
}