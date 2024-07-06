using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecart.Core.Services;
public interface IEventPublisher<in T>
{
    Task PublishEventAsync(string topicName, T eventData, CancellationToken token = default);
}
