using Contracts.Models;
using Contracts.Models.SQL;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connectionString ="Server=CPX-RMS80SJLM7T\\SQLEXPRESS02;initial catalog = contracte.go.ro; trusted_connection=true;TrustServerCertificate=True";

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DataBaseContext>(option => { option.UseSqlServer(connectionString); }, ServiceLifetime.Singleton);

builder.Services.AddTransient<IRootService, RootService>();
builder.Services.AddTransient<ICarContractDataService, CarContractDataService>();
builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<IPersonService, PersonService>();
builder.Services.AddTransient<IFinancialInfoService, FinancialInfoService>();
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
