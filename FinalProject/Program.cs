using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FinalProject.Data;
using System.Configuration;
using Microsoft.AspNetCore.Authorization;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//Checks app & database status 
builder.Services.AddHealthChecks();

builder.Services.AddResponseCaching();
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
    app.UseHsts();
}

// Status code if page cannot be found
app.UseStatusCodePages(async statusCodeContext =>
{
    statusCodeContext.HttpContext.Response.ContentType = Text.Plain;

    await statusCodeContext.HttpContext.Response.WriteAsync(
        $"Status Code Page: {statusCodeContext.HttpContext.Response.StatusCode}");
});

app.UseHttpsRedirection();

//configures database healthcheck
app.MapHealthChecks("/healthz")
    .RequireAuthorization();



app.UseResponseCaching();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

CreateDbIfNotExists(app);

app.MapRazorPages();

app.Run();

