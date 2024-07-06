using Dapr.Client;
using Ecart.Core.Configurations;
using Microsoft.Extensions.Options;

namespace Ecart.Core.Services;
public class EventPublisher<T> : IEventPublisher<T>
{
    private readonly DaprClient _daprClient;
    private readonly string _pubsubName;

    public EventPublisher(DaprClient daprClient, IOptions<DaprConfig> daprConfig)
    {
        if (string.IsNullOrEmpty(daprConfig?.Value?.PubsubName))
        {
            throw new ArgumentNullException(nameof(daprConfig));
        }

        _daprClient = daprClient ?? throw new ArgumentNullException(nameof(daprClient));
        _pubsubName = daprConfig.Value.PubsubName;
    }

    public async Task PublishEventAsync(string topicName, T eventData, CancellationToken token = default)
    {
        await _daprClient.PublishEventAsync(_pubsubName, topicName, eventData, cancellationToken: token);
    }
}
