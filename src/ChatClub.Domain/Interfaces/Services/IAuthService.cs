using ChatClub.Domain.Dto;
using Microsoft.AspNet.Identity.EntityFramework;
using System.IdentityModel.Tokens.Jwt;


namespace ChatClub.Domain.Interfaces.Services
{
    public interface IAuthService  
    {
        Task<LoginDto?> LoginAsync(UserDto user);
    }
}
