using AutoMapper;
using ChatClub.Domain.Dto;
using ChatClub.Domain.Entities;
using ChatClub.Domain.Extension;
using ChatClub.Domain.Interfaces.Repositories;
using ChatClub.Domain.Interfaces.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClub.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _user;
        private readonly IMapper _mapper;

        public UserService( IUserRepository user, IMapper map)
        {
            _user = user;
            _mapper = map;
        }

        public async Task<UserDto> GetUserAsync(UserDto user)
        {
            var userEntity = await _user.GetUserAsync(user.Email!);

            return _mapper.Map<UserDto>(userEntity);
        }

        public async Task SaveUserAsync(UserDto user)
        {
            user.Password = user.Password!.Encrypt();

            await _user.SaveAsync(_mapper.Map<UserEntity>(user));
        }
    }
}
