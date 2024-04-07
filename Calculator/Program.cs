using Calculator.Components;
using Calculator.Services;
using Calculator.Services.Database;
using Calculator.Shared;
using Grpc.Net.Client.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// gRPC
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();
builder.Services
    .AddGrpcClient<CalculatorGrpc.CalculatorGrpcClient>
        (options => options.Address = new Uri(builder.Configuration["ApiBaseUrl"]!))
    .ConfigurePrimaryHttpMessageHandler
        (() => new GrpcWebHandler(new HttpClientHandler()));

builder.Services.AddTransient<IDatabaseService, DatabaseService>();

// Logging
builder.Logging.AddLog4Net();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Calculator.Client._Imports).Assembly);

// gRPC
app.UseGrpcWeb();
app.MapGrpcService<CalculatorService>().EnableGrpcWeb();
app.MapGrpcReflectionService(); // command: grpcui localhost:7032

app.Run();