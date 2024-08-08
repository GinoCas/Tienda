using API.Configuration;

namespace API.Managers.Models
{
    public interface ISQLModel
    {
        public DataBaseConnection dbConnection { get; set; }
        public void OpenConnection();
        public void CloseConnection();
        public void ExecuteQuery(string query, params object[] parameters);
    }
}
