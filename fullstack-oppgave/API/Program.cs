using Application.Services;
using Application;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Data.DBWrapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<UserDbContext>();
builder.Services.AddDbContext<UserDbContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDBWrapper, DBWrapper>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(DefaultProfile));

var allowedUrls = builder.Configuration.GetSection("FrontEnd-Urls").GetChildren().Select(c => c.Value).ToArray();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins(allowedUrls).AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Error");
    //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

//app.UseHttpsRedirection();
//app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
