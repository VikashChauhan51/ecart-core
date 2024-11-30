using Ecart.Core.Loggers.Enrichers;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Ecart.Core.Loggers;
public static class SeriLogger
{
    public static Action<HostBuilderContext, LoggerConfiguration> Configure =>
       (context, configuration) =>
       {

           configuration
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.With(
                new ThreadIdEnricher(),
                new CLREnricher(),
                new MachineEnricher(),
                new ProcessEnricher())
                .WriteTo.Debug()
                .WriteTo.Console()
                .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                .Enrich.WithProperty("Application", context.HostingEnvironment.ApplicationName)
                .ReadFrom.Configuration(context.Configuration);
       };
}
