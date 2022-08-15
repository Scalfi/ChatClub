using ChatClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace ChatClub.Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ) : base(options)
        {
           
        }

        public DbSet<UserEntity>? Users { get; set; }

        public DbSet<MessageEntity>? Messages { get; set; }

    }
}
