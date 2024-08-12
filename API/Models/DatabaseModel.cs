using API.Configuration;
using System.Data;

namespace API.Models
{
    public interface IDBManager
    {
        public DataBaseConnection dbConnection { get; set; }
        public Task OpenConnectionAsync();
        public Task CloseConnectionAsync();
        public Task<DataTable> ExecuteQueryAsync(string query, params DBParameter[] parameters);
        public Task<int> ExecuteNonQueryAsync(string query, params DBParameter[] parameters);
    }
    public class DBParameter
    {
        public string Name;
        public object Value;
        public DBParameter(string name, object value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
