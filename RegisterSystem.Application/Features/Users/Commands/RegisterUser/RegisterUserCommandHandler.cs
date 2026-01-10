using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RegisterSystem.Application.Common.Interfaces;
using RegisterSystem.Domain.Entities;

namespace RegisterSystem.Application.Features.Users.Commands.RegisterUser
{
  public class RegisterUserCommandHandler(
    UserManager<ApplicationUser> userManager,
    IJwtProvider jwtProvider
  ) : IRequestHandler<RegisterUserCommand, string>
  {
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
      var user = new ApplicationUser(request.FirstName, request.LastName)
      {
        Email = request.Email,
        UserName = request.Email
      };

      var result = await _userManager.CreateAsync(user, request.Password);

      if (!result.Succeeded)
      {
        var errors = string.Join(", ", result.Errors.Select((e) => e.Description));
        throw new ValidationException($"Registration failed: {errors}");
      }

      return _jwtProvider.GenerateToken(user, []);
    }
  }
}