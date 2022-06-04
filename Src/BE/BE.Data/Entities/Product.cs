﻿namespace BE.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Img { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Qty { get; set; }
    }
}
