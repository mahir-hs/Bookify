using Bookify.Domain.Apartments;
namespace Bookify.Domain.Users;

public interface IApartmentRepository
{
    Task<Apartment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}