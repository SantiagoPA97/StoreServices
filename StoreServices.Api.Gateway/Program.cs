using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using StoreServices.API.Gateway.Interfaces;
using StoreServices.API.Gateway.MessageHandler;
using StoreServices.API.Gateway.Services;

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddSingleton<IAuthor, AuthorService>();
builder.Services.AddHttpClient("AuthorService", c => c.BaseAddress = new Uri(builder.Configuration["Services:Author"]));
builder.Services.AddOcelot(configuration).AddDelegatingHandler<BookHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

await app.UseOcelot();

app.Run();
