namespace Bookify.Domain.Apartments;

public record Address
(
    string Street,
    string City,
    string Country,
    string ZipCode,
    string State
);
