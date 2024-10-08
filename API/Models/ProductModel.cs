﻿namespace API.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public uint Stock { get; set; }
    }
}
