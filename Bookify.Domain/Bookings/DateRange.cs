namespace Bookify.Domain.Bookings;

public record class DateRange
{
    private DateRange()
    {

    }

    public DateOnly Start { get; private set; }
    public DateOnly End { get; private set; }
    public int LengthInDays => End.DayNumber - Start.DayNumber;
    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if (start > end)
            throw new ArgumentException("Start date must be less than or equal to end date.");

        return new DateRange
        {
            Start = start,
            End = end
        };
    }
}