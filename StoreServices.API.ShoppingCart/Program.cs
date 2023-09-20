using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.API.ShoppingCart.Application;
using StoreServices.API.ShoppingCart.Interfaces;
using StoreServices.API.ShoppingCart.Persistency;
using StoreServices.API.ShoppingCart.RemoteService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShoppingCartContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("ShoppingCartConnectionString")));

builder.Services.AddMediatR(typeof(New.Handler).Assembly);

builder.Services.AddAutoMapper(typeof(GetShoppingCartById.Handler));

builder.Services.AddHttpClient("Books", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Books"]);
});

var app = builder.Build();

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
