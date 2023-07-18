using SMS.Services;
using SMS.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductServices userServices;
        public ProductsController(IProductServices userService)
        {
            this.userServices = userService;
        }
        public HttpResponse Add()
        {
            return this.View();
        }
        public HttpResponse Create()
        {
            return this.View();
        }
        [HttpPost]
        public HttpResponse Create(CreateProductInputModel input)
        {
            if(string.IsNullOrEmpty(input.Name) || input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Error("Invalid name.");
            }
            if((double)input.Price < 0.05 || input.Price > 1000)
            {
                return this.Error("Ivalid Price.");
            }
            this.userServices.Create(input.Name, input.Price);
            return this.Redirect("/");
        }
    }
}
