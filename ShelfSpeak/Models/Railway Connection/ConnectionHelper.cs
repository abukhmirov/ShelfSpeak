using Npgsql;

namespace ShelfSpeak.Models.Railway_Connection
{
    public static class ConnectionHelper
    {
        public static string GetConnectionString(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SHELFSPEAK_DB_CONNECTION_STRING");
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            return string.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl);
        }

        //build the connection string from the environment. i.e. Heroku
        private static string BuildConnectionString(string databaseUrl)
        {
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = Environment.GetEnvironmentVariable("PGHOST"),
                Port = int.Parse(Environment.GetEnvironmentVariable("PGPORT")),
                Username = Environment.GetEnvironmentVariable("PGUSER"),
                Password = Environment.GetEnvironmentVariable("PGPASSWORD"),
                Database = Environment.GetEnvironmentVariable("PGDATABASE"),
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };
            return builder.ToString();
        }
    }
}
