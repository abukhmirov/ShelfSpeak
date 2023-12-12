using Microsoft.EntityFrameworkCore;
using ShelfSpeak.DataAccess;
using Microsoft.AspNetCore.Identity;
using ShelfSpeak.Models;
using ShelfSpeak.Interfaces;
using ShelfSpeak.Services;
using ShelfSpeak.Models.Railway_Connection;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IOpenLibraryService, OpenLibraryService>();

var connection = Environment.GetEnvironmentVariable("DATABASE_URL");
Console.WriteLine(connection);

/*  builder.Configuration["SHELFSPEAK_DB_CONNECTION_STRING"]   .EnableSensitiveDataLogging()  */
builder.Services.AddDbContext<ShelfSpeakContext>(
    options =>
        options
            .UseNpgsql(
                Environment.GetEnvironmentVariable("DATABASE_URL")

            )
            
            .UseSnakeCaseNamingConvention()
            
);

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ShelfSpeakContext>();

var app = builder.Build();
var scope = app.Services.CreateScope();
await DataHelper.ManageDataAsync(scope.ServiceProvider);

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
