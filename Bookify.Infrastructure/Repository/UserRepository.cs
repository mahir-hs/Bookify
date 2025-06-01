using Bookify.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Repository;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DbContext dbContext) : base(dbContext)
    {
    }
}