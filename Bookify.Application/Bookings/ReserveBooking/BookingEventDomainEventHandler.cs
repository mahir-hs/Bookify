using Bookify.Application.Abstractions.Email;
using Bookify.Domain.Bookings;
using Bookify.Domain.Bookings.Events;
using Bookify.Domain.Users;
using MediatR;

namespace Bookify.Application.Bookings.ReserveBooking;

internal sealed class BookingEventDomainEventHandler : INotificationHandler<BookingReservedDomainEvent>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public BookingEventDomainEventHandler(IBookingRepository bookingRepository, IUserRepository userRepository, IEmailService emailService)
    {
        _bookingRepository = bookingRepository;
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(notification.BookingId, cancellationToken);
        if (booking is null)
        {
            return; // Handle the case where the booking is not found, if necessary
        }

        var user = await _userRepository.GetByIdAsync(booking.UserId, cancellationToken);
        if (user is null)
        {
            return; // Handle the case where the user is not found, if necessary
        }

        var subject = "Booking Confirmation";
        var body = $"Your booking for apartment {booking.ApartmentId} has been successfully reserved from {booking.Duration.Start} to {booking.Duration.End}.";

        await _emailService.SendAsync(user.Email, subject, body);
    }
}