
namespace Ecart.Core.Configurations;
public class CircuitBreakerConfig
{
    public int HandledEventsAllowedBeforeBreaking { get; init; }
    public int DurationOfBreakSeconds { get; init; }
}
