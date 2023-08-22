using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using WindemereManorWeb.Config;
using WindemereManorWeb.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var sqlBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("WindemereManorWebContext"));
var dbSettings = builder.Configuration.GetSection("DbSettings").Get<DbSettings>();
sqlBuilder.UserID = dbSettings.ManorUserId;
sqlBuilder.Password = dbSettings.ManorPassWd;

builder.Services.AddDbContext<WindemereManorWebContext>(options =>
    options.UseSqlServer(sqlBuilder.ConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
