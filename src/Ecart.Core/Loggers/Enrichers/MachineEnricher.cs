using Serilog.Core;
using Serilog.Events;

namespace Ecart.Core.Loggers.Enrichers;
public class MachineEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
                 "MachineName", Environment.MachineName));

        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
                 "OSVersion", Environment.OSVersion));
    }
}
