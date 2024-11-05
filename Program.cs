using EWeather;
using EWeather.Helpers;
using EWeather.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

#region Project Services

builder.Services.AddHttpClient(Configuration.HTTP_CLIENT_RESILIENCE_PIPELINE).AddStandardResilienceHandler();
builder.Services.AddSingleton<IHttpHelper, HttpHelper>();
builder.Services.AddSingleton<IWeatherService, WeatherService>();

#endregion

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
