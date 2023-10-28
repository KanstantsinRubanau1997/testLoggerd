using Loging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using log4net;
using log4net.Config;
using System.Reflection;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddHostedService<HostedService>();

var serilogLogger = new LoggerConfiguration()
    .MinimumLevel.Verbose()
    .WriteTo.Console()
    .WriteTo.File(@".\Log-{Date}.txt")
    .CreateLogger();

var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo("log4netconfig.config"));


builder.Services.AddLogging((loggingBuilder) =>
{
    loggingBuilder.ClearProviders();
    //loggingBuilder.AddSerilog(serilogLogger);
    //loggingBuilder.AddNLog();
    loggingBuilder.AddProvider(new Log4NetProvider());
});

var host = builder.Build();

await host.RunAsync();
