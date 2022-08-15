using ChatClub.Domain.Dto;
using ChatClub.Domain.Interfaces.Services;


namespace ChatClub.Application.Services
{
    public class RegisterService : IRegisterService
    {
        private IUserService _user;

        public RegisterService(IUserService user)
        {
            _user = user;
        }
        public async Task RegisterAsync(UserDto user)
        {
            await _user.SaveUserAsync(user);
        }
    }
}
