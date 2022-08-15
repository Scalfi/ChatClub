using AutoMapper;
using ChatClub.Domain.Dto;
using ChatClub.Domain.Entities;
using ChatClub.Domain.Extension;
using ChatClub.Domain.Interfaces.Services;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChatClub.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly IUserService _user;
        private readonly IMapper _mapper;

        public AuthService(IConfiguration config, IUserService user, IMapper mapper)
        {
            _config = config;
            _user = user;
            _mapper = mapper;
        }


        private string GenerateToken(UserDto user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email!),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<LoginDto?> LoginAsync(UserDto userDto)
        {
            var userAuth = await _user.GetUserAsync(userDto);
            if (userAuth != null && userAuth.Password == userDto.Password!.Encrypt())
            {
                var login = _mapper.Map<LoginDto>(userDto);
                login.Token = GenerateToken(userDto);
                return login;
                
            }
            return null;
        }
    }
}
