using JournalApiApp.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using JournalWebApplication.Data;
using JournalWebApplication.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("JournalWebApplicationContextConnection") ?? throw new InvalidOperationException("Connection string 'JournalWebApplicationContextConnection' not found.");

builder.Services.AddDbContext<JournalWebApplicationContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddDefaultIdentity<JournalWebApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<JournalWebApplicationContext>();
builder.Services.AddDbContext<JournalDbContext>();

// Add services to the container.
builder.Services.AddRazorPages();

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

