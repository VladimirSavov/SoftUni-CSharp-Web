using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Services
{
    public interface IProductServices
    { 

        void Create(string name, decimal price);
    }
}
