using API.Configuration;
using API.Models;
using MySqlConnector;
using System.Data;
using System.Data.Common;

namespace API.Managers
{
    public class MySQLManager : ISQLManager
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
            if (mysqlConnection.State == ConnectionState.Open){ return; }
            await mysqlConnection.OpenAsync();
        }
        public async Task CloseConnectionAsync() 
        {
            if (mysqlConnection.State == ConnectionState.Closed) { return; }
            await mysqlConnection.CloseAsync();
        }
        public async Task<DataTable> ExecuteQueryAsync(string query, params DBParameter[] parameters)
        {
            await OpenConnectionAsync();
            using (var cmd = new MySqlCommand(query, mysqlConnection))
            {
                AddParameters(cmd, parameters);
                using (var reader = cmd.ExecuteReaderAsync())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader.Result);
                    await CloseConnectionAsync();
                    return dt;
                }
            }
        }
        public async Task<int> ExecuteNonQueryAsync(string query, params DBParameter[] parameters)
        {
            await OpenConnectionAsync();
            using (var cmd = new MySqlCommand(query, mysqlConnection))
            {
                AddParameters(cmd, parameters);
                int result = await cmd.ExecuteNonQueryAsync();
                await CloseConnectionAsync();
                return result;
            }
        }
        public void AddParameters(DbCommand cmd, params DBParameter[] parameters)
        {
            foreach (DBParameter param in parameters)
            {
                cmd.Parameters.Add(new MySqlParameter(param.Name, param.Value));
            }
        }
    }
}
