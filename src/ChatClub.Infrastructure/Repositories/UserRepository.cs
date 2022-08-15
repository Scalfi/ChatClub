using ChatClub.Domain.Entities;
using ChatClub.Domain.Interfaces.Repositories;
using ChatClub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ChatClub.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DataContext _db;

        public UserRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<UserEntity?> GetUserAsync(string email)
        {
            return await _db.Users!.FirstOrDefaultAsync(a => a.Email == email); 
        }

        public async Task SaveAsync(UserEntity entity)
        {
            try
            {
               await _db.Users!.AddAsync(entity);
               await _db.SaveChangesAsync();
            } catch (Exception e)
            {
                var error = e.Message;
            }
        
        }
    }
}
