﻿using Serilog.Core;
using Serilog.Events;

namespace Ecart.Core.Loggers.Enrichers;
public class ThreadIdEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
                "ThreadId", Environment.CurrentManagedThreadId));
    }
}
