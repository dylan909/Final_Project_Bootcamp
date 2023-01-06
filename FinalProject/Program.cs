using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FinalProject.Data;
using System.Configuration;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddControllers();
builder.Services.AddDbContext<FinalProjectContext>(option => option.UseSqlite(builder.Configuration.GetConnectionString("FinalProjectContext")));

void CreateDbIfNotExists(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<FinalProjectContext>();
        Dbinitializer.Initialize(context);
    }
}

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

CreateDbIfNotExists(app);

app.MapRazorPages();

app.Run();

