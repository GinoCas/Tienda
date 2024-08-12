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
                user.Password = row["user_password"].ToString();
                user.EntryDate = (DateTime)row["user_entrydate"];
                list.Add(user);
            }
            return list;
        }
        public async Task<UserModel?> GetUser(string user)
        {
            UserModel user_found;
            try
            {
                user_found = ConvertDataTable(await ApplicationController.dbManager.ExecuteQueryAsync(
                "SELECT * FROM Users " +
                $"WHERE user_name = @user_name", 
                new DBParameter("@user_name", user)))[0];
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
                "(user_name, user_password) " +
                "VALUES" +
                $"(@user_name, @user_password);", 
                new DBParameter("@user_name", user.Name),
                new DBParameter("@user_password", user.Password));
        }
        /*
        public async Task<int> InsertProduct(ProductModel product)
        {
            return await ApplicationController.dbManager.ExecuteNonQueryAsync(
                "INSERT INTO PRODUCTO" +
                "(prod_nombre, prod_descripcion, prod_precio) " +
                "VALUES" +
                $"('{product.Nombre}', '{product.Descripcion}', {product.Precio});");
        }
        public async Task<int> UpdateProduct(ProductModel product)
        {
            return await ApplicationController.dbManager.ExecuteNonQueryAsync(
                "UPDATE PRODUCTO " +
                "SET " +
                $"prod_nombre = '{product.Nombre}', " +
                $"prod_descripcion = '{product.Descripcion}', " +
                $"prod_precio = {product.Precio} " +
                $"WHERE prod_id = {product.Id};");
        }
        public async Task<int> DeleteProduct(ProductModel product)
        {
            return await ApplicationController.dbManager.ExecuteNonQueryAsync(
                "DELETE FROM PRODUCTO " +
                $"WHERE prod_id = {product.Id};");
        }*/
    }
}
