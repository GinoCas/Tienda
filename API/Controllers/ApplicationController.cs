using API.Configuration;
using API.Managers;
using API.Models;

namespace API.Controllers
{
    public class ApplicationController
    {
        public static IDatabaseModel dbManager = new MySQLManager(new DataBaseConnection());
    }
}
