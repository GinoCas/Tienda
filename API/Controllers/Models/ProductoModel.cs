﻿namespace API.Controllers.Models
{
    public class ProductoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
}
