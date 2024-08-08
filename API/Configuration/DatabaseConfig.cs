namespace API.Configuration
{
    public class DataBaseConnection
    {
        public DataBaseConnection()
        {
            var build = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            connectionString = build.GetConnectionString("mysqlDB");
        }
        public string? connectionString { get; }
    }
}
