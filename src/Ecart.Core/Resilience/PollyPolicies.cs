using Ecart.Core.Configurations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Extensions.Http;

namespace Ecart.Core.Resilience;

public class PollyPolicies(ILogger<PollyPolicies> logger,
    IOptions<CircuitBreakerConfig> circuitBreakerConfig,
    IOptions<RetryConfig> retryConfig)
{

    public IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(
                retryCount: retryConfig.Value.RetryCount,
                sleepDurationProvider: attempt => TimeSpan.FromSeconds(Math.Pow(retryConfig.Value.RetryAfterSeconds, attempt)),
                onRetry: (outcome, timespan, attempt, context) =>
                {
                    logger.LogWarning("Retry attempt {Attempt} after {TotalSeconds} seconds due to {Message}",
                        attempt,
                        timespan.TotalSeconds,
                        outcome.Exception?.Message ?? outcome.Result.ReasonPhrase);
                });
    }

    public IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(
                handledEventsAllowedBeforeBreaking: circuitBreakerConfig.Value.HandledEventsAllowedBeforeBreaking,
                durationOfBreak: TimeSpan.FromSeconds(circuitBreakerConfig.Value.DurationOfBreakSeconds),
                onBreak: (outcome, breakDelay) =>
                {
                    logger.LogError("Circuit broken due to {Message}. Break duration: {TotalSeconds} seconds.",
                        outcome.Exception?.Message ?? outcome.Result.ReasonPhrase, breakDelay.TotalSeconds);
                },
                onReset: () =>
                {
                    logger.LogInformation("Circuit reset.");
                });
    }
}

