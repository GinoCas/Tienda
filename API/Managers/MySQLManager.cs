using API.Configuration;
using API.Managers.Models;
using MySqlConnector;

namespace API.Managers
{
    public class MySQLManager : ISQLModel
    {
        public DataBaseConnection dbConnection { get; set; }
        private MySqlConnection mysqlConnection;

        public MySQLManager(DataBaseConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            mysqlConnection = new MySqlConnection(dbConnection.connectionString);
        }
        public void OpenConnection()
        {
            if (mysqlConnection.State == System.Data.ConnectionState.Open){ return; }
            mysqlConnection.Open();
        }
        public void CloseConnection() 
        {
            if (mysqlConnection.State == System.Data.ConnectionState.Closed) { return; }
            mysqlConnection.Close();
        }
        public async void ExecuteQuery(string query, params object[] parameters)
        {
            OpenConnection();
            using (var cmd = new MySqlCommand(query, mysqlConnection))
            {
                cmd.CommandType = System.Data.CommandType.Text;
                using (var reader = cmd.ExecuteReaderAsync())
                {
                    while (await reader.Result.ReadAsync())
                    {
                        for (int i = 0; i < reader.Result.FieldCount; i++)
                        {
                            Console.WriteLine($"{reader.Result.GetName(i)}: {reader.Result.GetValue(i)}");
                        }
                    }
                }
            }
            CloseConnection();
        }
    }
}
