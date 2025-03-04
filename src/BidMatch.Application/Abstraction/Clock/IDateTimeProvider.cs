namespace BidMatch.Application.Abstraction.Clock;

public interface IDateTimeProvider
{
    DateTime Now { get; }
    DateTime UtcNow { get; }
}