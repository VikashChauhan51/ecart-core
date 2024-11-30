using Serilog.Core;
using Serilog.Events;


namespace Ecart.Core.Loggers.Enrichers;
internal class ProcessEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
                "ProcessId", Environment.ProcessId));

        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
                 "MemorySet", Environment.WorkingSet));
    }
}
