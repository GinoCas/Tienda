using API.Configuration;
using API.Models;
using MySqlConnector;
using System.Data;

namespace API.Managers
{
    public class MySQLManager : IDatabaseModel
    {
        public DataBaseConnection dbConnection { get; set; }
        private MySqlConnection mysqlConnection;

        public MySQLManager(DataBaseConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            mysqlConnection = new MySqlConnection(dbConnection.connectionString);
        }
        public async Task OpenConnectionAsync()
        {
            if (mysqlConnection.State == System.Data.ConnectionState.Open){ return; }
            await mysqlConnection.OpenAsync();
        }
        public async Task CloseConnectionAsync() 
        {
            if (mysqlConnection.State == System.Data.ConnectionState.Closed) { return; }
            await mysqlConnection.CloseAsync();
        }
        public async Task<DataTable> ExecuteQueryAsync(string query)
        {
            await OpenConnectionAsync();
            using (var cmd = new MySqlCommand(query, mysqlConnection))
            {;
                using (var reader = cmd.ExecuteReaderAsync())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader.Result);
                    await CloseConnectionAsync();
                    return dt;
                }
            }
        }
        public async Task<int> ExecuteNonQueryAsync(string query)
        {
            await OpenConnectionAsync();
            using (var cmd = new MySqlCommand(query, mysqlConnection))
            {
                int result = await cmd.ExecuteNonQueryAsync();
                await CloseConnectionAsync();
                return result;
            }
        }
    }
}
