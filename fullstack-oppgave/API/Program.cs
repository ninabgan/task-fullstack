using Application.Services;
using Application;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Data.DBWrapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// instansiere ulike scopes for Dependency Injection
builder.Services.AddTransient<UserDbContext>();
builder.Services.AddDbContext<UserDbContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDBWrapper, DBWrapper>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(DefaultProfile));

// tillate frontend å kalle på backend
var allowedUrls = builder.Configuration.GetSection("FrontEnd-Urls").GetChildren().Select(c => c.Value).ToArray();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins(allowedUrls).AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
