using SMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Services
{
    public class ProductServices : IProductServices
    {
        private readonly SMSDbContext db;
        public ProductServices(SMSDbContext db)
        {
            this.db = db;
        }
        public void Create(string name, decimal price)
        {
            var product = new Product
            {
                Name = name,
                Price = price
            };
            this.db.Add(product);
            this.db.SaveChanges();
        }
    }
}
