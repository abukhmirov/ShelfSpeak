using Microsoft.EntityFrameworkCore;
using ShelfSpeak.DataAccess;
using Microsoft.AspNetCore.Identity;
using ShelfSpeak.Models;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration["SHELFSPEAK_DB_CONNECTION_STRING"]
//                    ?? throw new InvalidOperationException(
//                        "Connection string 'ShelfSpeak' not found."
//                    )
//            )
//            .EnableSensitiveDataLogging()

//            .UseSnakeCaseNamingConvention();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ShelfSpeakContext>(
    options =>
        options
            .UseNpgsql(
                builder.Configuration["SHELFSPEAK_DB_CONNECTION_STRING"]
                    ?? throw new InvalidOperationException(
                        "Connection string 'ShelfSpeak' not found."
                    )
            )
            .EnableSensitiveDataLogging()

            .UseSnakeCaseNamingConvention()
);

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ShelfSpeakContext>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
