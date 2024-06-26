﻿using Dapr.Client;
using Ecart.Core.Configurations;
using Microsoft.Extensions.Options;

namespace Ecart.Core.Services;
public class SecretStore : ISecretStore
{
    private readonly DaprClient _daprClient;
    private readonly string _storeName;
    public SecretStore(DaprClient daprClient, IOptions<DaprConfig> daprConfig)
    {
        if (string.IsNullOrEmpty(daprConfig?.Value?.SecretstoreName))
        {
            throw new ArgumentNullException(nameof(daprConfig));
        }

        _daprClient = daprClient ?? throw new ArgumentNullException(nameof(daprClient));
        _storeName = daprConfig.Value.SecretstoreName;
    }

    public async Task<Dictionary<string, string>> FetchAsync(string key, CancellationToken token = default) => await _daprClient.GetSecretAsync(_storeName, key, cancellationToken: token);

}
