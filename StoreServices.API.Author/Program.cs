using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.API.Author.Application;
using StoreServices.API.Author.Persistency;
using StoreServices.API.Author.RabbitMQHandler;
using StoreServices.RabbitMQ.Bus;
using StoreServices.RabbitMQ.Bus.Bus;
using StoreServices.RabbitMQ.Bus.EventQueue;
using StoreServices.RabbitMQ.Bus.Implement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IRabbitEventBus, RabbitEventBus>(sp =>
{
    var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
    return new RabbitEventBus(sp.GetService<IMediator>(), scopeFactory);
});

builder.Services.AddTransient<EmailEventHandler>();
builder.Services.AddTransient<IEventHandler<EmailEventQueue>, EmailEventHandler>();
builder.Services.AddControllers()
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<New>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AuthorContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("AuthorConnectionString"));
});

builder.Services.AddMediatR(typeof(New.Handler).Assembly);

builder.Services.AddAutoMapper(typeof(GetAll.Handler));

var app = builder.Build();
var eventBus = app.Services.GetRequiredService<IRabbitEventBus>();
eventBus.Subscribe<EmailEventQueue, EmailEventHandler>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
