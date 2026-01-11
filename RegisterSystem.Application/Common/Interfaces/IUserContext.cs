namespace RegisterSystem.Application.Common.Interfaces
{
  public interface IUserContext
  {
    string? GetEmail();
    string? GetUserId();
  }
}