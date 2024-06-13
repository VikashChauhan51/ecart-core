
namespace Ecart.Core.Configurations;
public class ConcurrencyLimiterConfig
{
    public int PermitLimit { get; init; }
    public int QueueProcessingOrder { get; init; }
    public int QueueLimit { get; init; }
}
