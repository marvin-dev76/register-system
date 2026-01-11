using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegisterSystem.Application.Features.Users.Queries.GetUserProfile;

namespace RegisterSystem.API.Controllers
{
  public class TestController(IMediator mediator) : ApiControllerBase(mediator)
  {
    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> Private(CancellationToken cancellationToken)
    {
      var query = new GetUserProfileQuery();
      var result = await _mediator.Send(query, cancellationToken);
      return Ok(result);
    }
  }
}