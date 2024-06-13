using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace Ecart.Core.HealthChecks;
public class ApiHealthCheck(ILogger<ApiHealthCheck> logger) : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var result = HealthCheckResult.Healthy();
        logger.LogInformation("ApiHealthCheck: {Health}", result);
        return Task.FromResult(result);
    }
}
