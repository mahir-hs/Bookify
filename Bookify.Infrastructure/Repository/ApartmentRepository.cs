using Bookify.Domain.Apartments;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Repository;

internal sealed class ApartmentRepository : Repository<Apartment>, IApartmentRepository
{
    public ApartmentRepository(DbContext dbContext) : base(dbContext)
    {
    }
}