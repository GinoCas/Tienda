using API.Configuration;
using System.Data;

namespace API.Models
{
    public interface IDatabaseModel
    {
        public DataBaseConnection dbConnection { get; set; }
        public Task OpenConnectionAsync();
        public Task CloseConnectionAsync();
        public Task<DataTable> ExecuteQueryAsync(string query);
        public Task<int> ExecuteNonQueryAsync(string query);
    }
}
