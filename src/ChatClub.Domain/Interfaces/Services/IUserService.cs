using ChatClub.Domain.Dto;

namespace ChatClub.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(UserDto user);
        Task SaveUserAsync(UserDto user);
    }
}
