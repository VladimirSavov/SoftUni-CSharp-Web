using SMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SMS.Data
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }

}
