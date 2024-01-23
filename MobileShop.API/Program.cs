using Microsoft.EntityFrameworkCore;
using MobileShop.Entity.Models;
using MobileShop.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configuration = builder.Configuration;
builder.Services.AddDbContext<FstoreContext>(opt =>
{
    opt.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
});
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IEncryptionService, EncryptionService>();
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
