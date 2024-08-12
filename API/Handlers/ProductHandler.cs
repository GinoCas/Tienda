using API.Controllers;
using API.Models;
using System.Data;

namespace API.Handlers
{
    public class ProductHandler
    {
        private List<ProductModel> ConvertDataTable(DataTable dataTable)
        {
            var list = new List<ProductModel>();
            foreach(DataRow row in dataTable.Rows)
            {
                var product = new ProductModel();
                product.Id = (int)row["prod_id"];
                product.Name = row["prod_name"].ToString();
                product.Description = row["prod_description"].ToString();
                product.Value = (decimal)row["prod_value"];
                list.Add(product);
            }
            return list;
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            return ConvertDataTable(await ApplicationController.dbManager.ExecuteQueryAsync("SELECT * FROM PRODUCTS", []));
        }
        public async Task<int> PostProduct(ProductModel product)
        {
            return await ApplicationController.dbManager.ExecuteNonQueryAsync(
                "INSERT INTO PRODUCTS" +
                "(prod_nombre, prod_descripcion, prod_precio) " +
                "VALUES" +
                $"('{product.Name}', '{product.Description}', {product.Value});", []);
        }
        public async Task<int> PutProduct(ProductModel product)
        {
            return await ApplicationController.dbManager.ExecuteNonQueryAsync(
                "UPDATE PRODUCTS " +
                "SET " +
                $"prod_nombre = '{product.Name}', " +
                $"prod_descripcion = '{product.Description}', " +
                $"prod_precio = {product.Value} " +
                $"WHERE prod_id = {product.Id};", []);
        }
        public async Task<int> DeleteProduct(ProductModel product)
        {
            return await ApplicationController.dbManager.ExecuteNonQueryAsync(
                "DELETE FROM PRODUCTS " +
                $"WHERE prod_id = {product.Id};", []);
        }
    }
}
