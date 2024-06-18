using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecart.Core.Loggers;
public static class SeriLogger
{
    public static Action<HostBuilderContext, LoggerConfiguration> Configure =>
       (context, configuration) =>
       {

           configuration
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.With(new ThreadIdEnricher())
                .WriteTo.Debug()
                .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm} [{Level}] ({ThreadId}) {Message}{NewLine}{Exception}")
                .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                .Enrich.WithProperty("Application", context.HostingEnvironment.ApplicationName)
                .ReadFrom.Configuration(context.Configuration);
       };
}
