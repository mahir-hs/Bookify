using Bookify.Domain.Reviews;
using Bookify.Infrastructure.Repository;

namespace Bookify.Infrastructure.Repositories;

internal sealed class ReviewRepository : Repository<Review>, IReviewRepository
{
    public ReviewRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}