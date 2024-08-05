namespace API.Controllers.Models
{
    public class ProductoModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string? descripcion { get; set; }
        public decimal precio { get; set; }
    }
}
