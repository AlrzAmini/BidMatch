using BidMatch.Application.Abstraction.Clock;

namespace BidMatch.Infrastructure.Clock;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;

    public DateTime UtcNow => DateTime.UtcNow;
}