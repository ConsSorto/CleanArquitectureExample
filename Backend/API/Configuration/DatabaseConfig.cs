using DotNetEnv;
using Microsoft.Extensions.Configuration;

namespace API.Configuration
{
    public class DatabaseConfig
    {
        public string ConnectionString { get; }

        public DatabaseConfig() { 
            DotNetEnv.Env.Load();

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            string dbServer = configuration["DB_SERVER"] ?? "localhost";
            string dbPort = configuration["DB_PORT"] ?? "1234";
            string dbName = configuration["DB_NAME"] ?? "base";
            string dbUser = configuration["DB_USER"] ?? "cons";
            string dbPassword = configuration["DB_PASSWORD"] ?? "sorto";

            ConnectionString = $"Server={dbServer},{dbPort};Database={dbName};User Id={dbUser};Password={dbPassword};TrustServerCertificate=True;";
        }
    }
}
