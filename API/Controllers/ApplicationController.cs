using API.Configuration;
using API.Managers;
using API.Models;

namespace API.Controllers
{
    public class ApplicationController
    {
        public static IDBManager dbManager = new MySQLManager(new DataBaseConnection());
    }
}
