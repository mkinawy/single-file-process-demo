using System.Collections.Generic;
using SingleFileProcessDemo.Entities;

namespace SingleFileProcessDemo
{
    public class Database
    {
        public static readonly List<ProductEntity> Products;

        static Database()
        {
            Products = new List<ProductEntity>();
            for (var i = 0; i < 230; i++)
            {
                var id = i + 1;
                var product = new ProductEntity
                {
                    Id = id,
                    Name = $"Product {id}",
                    StockCount = id * 5,
                    Price = id * 3
                };
                Products.Add(product);
            }
        }
    }
}