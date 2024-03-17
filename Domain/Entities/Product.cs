using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductAPI.Infra.Database.Sqlite;

namespace ProductAPI.Domain.Entities
{
    public class Product
    {
        public Product(ProductModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Price = model.Price;
            Quantity = model.Quantity;
            Total = model.Price * model.Quantity;
        }

        public Product(int id, string name, decimal price, int quantity, decimal total)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            Total = total;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
