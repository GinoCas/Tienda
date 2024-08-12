using System.Data.Common;

namespace API.Models
{
    public interface ISQLManager : IDBManager
    {
        public void AddParameters(DbCommand cmd, params DBParameter[] parameters);
    }
}
