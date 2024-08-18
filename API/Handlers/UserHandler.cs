using API.Controllers;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Data;
using System.Data.Common;

namespace API.Handlers
{
    public class UserHandler
    {
        private List<UserModel> ConvertDataTable(DataTable dataTable)
        {
            var list = new List<UserModel>();
            foreach (DataRow row in dataTable.Rows)
            {
                var user = new UserModel();
                user.Id = (int)row["user_id"];
                user.Name = row["user_name"].ToString();
                user.Surname = row["user_surname"].ToString();
                user.Email = row["user_email"].ToString();
                user.Password = row["user_password"].ToString();
                user.CreatedAt = (DateTime)row["user_createdAt"];
                list.Add(user);
            }
            return list;
        }
        public async Task<UserModel?> GetUserByEmail(string email)
        {
            UserModel user_found;
            try
            {
                user_found = ConvertDataTable(await ApplicationController.dbManager.ExecuteQueryAsync(
                "SELECT * FROM Users " +
                $"WHERE user_email = @user_email", 
                new DBParameter("@user_email", email)))[0];
            }
            catch
            {
                return null;
            }
            return user_found;
        }
        public async Task<int> PostUser(UserModel user)
        {
            return await ApplicationController.dbManager.ExecuteNonQueryAsync(
                "INSERT INTO Users" +
                "(user_name, user_surname, user_email, user_password) " +
                "VALUES" +
                $"(@user_name, @user_surname, @user_email, @user_password);",
                new DBParameter("@user_name", user.Name),
                new DBParameter("@user_surname", user.Surname),
                new DBParameter("@user_email", user.Email),
                new DBParameter("@user_password", user.Password));
        }
    }
}
