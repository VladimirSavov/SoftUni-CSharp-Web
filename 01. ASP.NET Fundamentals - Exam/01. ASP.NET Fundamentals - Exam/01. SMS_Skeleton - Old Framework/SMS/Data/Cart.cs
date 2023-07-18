using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Data
{
    public class Cart
    {
        public Cart()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Products = new HashSet<Product>();
        }
        public string Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
