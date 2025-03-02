using Business.Abstract;
using Business.Concrete;
using Core.Extensions;
using Infrastructure.ExternalServices;
using Microsoft.Extensions.Options;
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Common.Constants;
using log4net;
using log4net.Config;
using System.Reflection;
using Autofac.Core;
using Core.Aspects.Logging;

var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ApiConfig>(builder.Configuration.GetSection("ApiSettings"));

builder.Services.AddHttpClient<IObiletApiService, ObiletApiService>((serviceProvider, client) =>
{
    var apiConfig = serviceProvider.GetRequiredService<IOptions<ApiConfig>>().Value;
    client.BaseAddress = new Uri(apiConfig.ApiUrl);
});

builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.IdleTimeout = TimeSpan.FromMinutes(60);

});

builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<IObiletApiService, ObiletApiService>();
builder.Services.AddScoped<IBusJourneyService, BusJourneyService>();
builder.Services.AddScoped<IBusLocationService, BusLocationService>();
builder.Services.AddScoped<ISessionService, SessionService>();

builder.Services.AddValidatorsFromAssemblyContaining<BusJourneyValidator>();

//builder.Services.AddLogging(loggingBuilder =>
//{
//    loggingBuilder.AddLog4Net();
//});

builder.Services.AddLogging(builder =>
{
    builder.AddProvider(new Log4NetLoggerProvider()); // Log4Net logger provider'ýný ekliyoruz
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.ConfigureSessionMiddlewareExtentions();
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
