using RpcClient.DependencyInjection;
using RpcClient.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRippleAccountClient();

builder.Services.AddOptions<RippleOptions>().Bind(builder.Configuration.GetSection("Ripple"))
    .ValidateDataAnnotations()
    .ValidateOnStart();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();