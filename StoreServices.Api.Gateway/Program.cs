using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using StoreServices.API.Gateway.MessageHandler;

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddOcelot(configuration).AddDelegatingHandler<BookHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

await app.UseOcelot();

app.Run();
