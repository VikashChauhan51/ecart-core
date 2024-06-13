﻿
namespace Ecart.Core.Services;
public interface ISecretStore
{
    Task<Dictionary<string, string>> FetchAsync(string key, CancellationToken token = default);
}
