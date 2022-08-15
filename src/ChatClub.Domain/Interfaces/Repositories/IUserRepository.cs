using ChatClub.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ChatClub.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task <UserEntity?> GetUserAsync(string email);
    }
}
