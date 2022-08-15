using ChatClub.Domain.Dto;

namespace ChatClub.Domain.Interfaces.Services
{
    public interface IRegisterService
    {
        Task RegisterAsync(UserDto register);
    }
}
