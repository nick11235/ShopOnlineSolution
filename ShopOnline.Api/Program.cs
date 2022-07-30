global using Microsoft.EntityFrameworkCore;
global using ShopOnline.Api.Entities;
global using ShopOnline.Api.Repositories;
global using ShopOnline.Api.Repositories.Contracts;
global using ShopOnline.Models.Dtos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using ShopOnline.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<ShopOnlineDbContext>(options=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopOnline"))
    );

builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy=>policy.WithOrigins("https://localhost:7216", "http://localhost:7216").AllowAnyMethod().WithHeaders(HeaderNames.ContentType));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
