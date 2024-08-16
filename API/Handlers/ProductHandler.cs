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
                product.Code = row["prod_code"].ToString();
                product.Description = row["prod_description"].ToString();
                product.Price = (decimal)row["prod_price"];
                product.Stock = (uint)row["prod_stock"];
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
                "(prod_name, prod_code, prod_description, prod_price, prod_stock) " +
                "VALUES" +
                $"(@prod_name, @prod_code, @prod_description, @prod_price, @prod_stock);", 
                new DBParameter("@prod_name", product.Name),
                new DBParameter("@prod_code", product.Code),
                new DBParameter("@prod_description", product.Description),
                new DBParameter("@prod_price", product.Price),
                new DBParameter("@prod_stock", product.Stock));
        }
        public async Task<int> PutProduct(ProductModel product)
        {
            return await ApplicationController.dbManager.ExecuteNonQueryAsync(
                "UPDATE PRODUCTS " +
                "SET " +
                "prod_name = @prod_name, " +
                "prod_descripcion = @prod_descripcion, " +
                "prod_price = @prod_price, " +
                "prod_stock = @prod_stock " +
                $"WHERE prod_id = @prod_id;", 
                new DBParameter("@prod_name", product.Name),
                new DBParameter("@prod_description", product.Description),
                new DBParameter("@prod_price", product.Price),
                new DBParameter("@prod_stock", product.Stock),
                new DBParameter("@prod_id", product.Id));
        }
        public async Task<int> DeleteProduct(ProductModel product)
        {
            return await ApplicationController.dbManager.ExecuteNonQueryAsync(
                "DELETE FROM PRODUCTS " +
                $"WHERE prod_id = @prod_id;",
                new DBParameter("@prod_id", product.Id));
        }
    }
}
