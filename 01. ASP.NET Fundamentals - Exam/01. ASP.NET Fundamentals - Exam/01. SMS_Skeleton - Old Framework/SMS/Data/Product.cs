using SMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SMS.Data
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
