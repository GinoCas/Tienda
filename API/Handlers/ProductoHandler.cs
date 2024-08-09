using API.Controllers;
using API.Models;
using System.Data;

namespace API.Handlers
{
    public class ProductoHandler
    {
        private List<ProductoModel> ConvertDataTable(DataTable dataTable)
        {
            var list = new List<ProductoModel>();
            foreach(DataRow row in dataTable.Rows)
            {
                var product = new ProductoModel();
                product.Id = (int)row["prod_id"];
                product.Nombre = row["prod_nombre"].ToString();
                product.Descripcion = row["prod_descripcion"].ToString();
                product.Precio = (decimal)row["prod_precio"];
                list.Add(product);
            }
            return list;
        }

        public async Task<List<ProductoModel>> GetProducts()
        {
            return ConvertDataTable(await ApplicationController.dbManager.ExecuteQueryAsync("SELECT * FROM PRODUCTO"));
        }
        public async Task<int> InsertProduct(ProductoModel product)
        {
            return await ApplicationController.dbManager.ExecuteNonQueryAsync(
                "INSERT INTO PRODUCTO" +
                "(prod_nombre, prod_descripcion, prod_precio) " +
                "VALUES" +
                $"('{product.Nombre}', '{product.Descripcion}', {product.Precio});");
        }
        public async Task<int> UpdateProduct(ProductoModel product)
        {
            return await ApplicationController.dbManager.ExecuteNonQueryAsync(
                "UPDATE PRODUCTO " +
                "SET " +
                $"prod_nombre = '{product.Nombre}', " +
                $"prod_descripcion = '{product.Descripcion}', " +
                $"prod_precio = {product.Precio} " +
                $"WHERE prod_id = {product.Id};");
        }
        public async Task<int> DeleteProduct(ProductoModel product)
        {
            return await ApplicationController.dbManager.ExecuteNonQueryAsync(
                "DELETE FROM PRODUCTO " +
                $"WHERE prod_id = {product.Id};");
        }
    }
}
