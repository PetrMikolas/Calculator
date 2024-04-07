using Calculator.Shared;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services
    .AddGrpcClient<CalculatorGrpc.CalculatorGrpcClient>
        (options => options.Address = new Uri(builder.HostEnvironment.BaseAddress))
    .ConfigurePrimaryHttpMessageHandler
        (() => new GrpcWebHandler(new HttpClientHandler()));

await builder.Build().RunAsync();