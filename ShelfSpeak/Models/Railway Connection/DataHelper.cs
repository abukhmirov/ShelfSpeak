using Microsoft.EntityFrameworkCore;
using ShelfSpeak.DataAccess;

namespace ShelfSpeak.Models.Railway_Connection
{
    public static class DataHelper
    {

        public static async Task ManageDataAsync(IServiceProvider svcProvider)
        {
            //Service: An instance of db context
            var dbContextSvc = svcProvider.GetRequiredService<ShelfSpeakContext>();

            //Migration: This is the programmatic equivalent to Update-Database
            await dbContextSvc.Database.MigrateAsync();
        }


    }
}
