using Microsoft.EntityFrameworkCore;
using ShelfSpeak.DataAccess;
using Microsoft.Extensions.Configuration;
using ShelfSpeak.Models;
using ShelfSpeak.Interfaces;
using ShelfSpeak.Services;
using System.Configuration;



//test
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IOpenLibraryService, OpenLibraryService>();


builder.Services.AddDbContext<ShelfSpeakContext>(
    options =>
        options
            .UseSqlServer(
                builder.Configuration["SHELFSPEAK_DB_CONNECTION_STRING"],
    options => options.EnableRetryOnFailure()
            //?? throw new InvalidOperationException(
            //    "Connection string 'ShelfSpeak' not found."
            //)
            )
            .EnableSensitiveDataLogging()


            .UseSnakeCaseNamingConvention()
);


builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ShelfSpeakContext>();
builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]);

var app = builder.Build();

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
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"Unhandled exception: {ex}");
    throw; // rethrow the exception
}

