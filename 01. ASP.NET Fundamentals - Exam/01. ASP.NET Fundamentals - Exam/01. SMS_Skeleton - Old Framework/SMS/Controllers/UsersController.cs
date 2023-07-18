using SMS.Services;
using SMS.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace SMS.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserServices userServices;
        public UsersController(IUserServices userService)
        {
            this.userServices = userService;
        }
        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            var userId = this.userServices.GetUserId(input.Username, input.Password);
            if (userId == null)
            {
                return this.Error("Invalid username or password.");
            }
            this.SignIn(userId);
            return this.Redirect("/");
        }
        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if(this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            if(string.IsNullOrEmpty(input.Username) || input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Error("Username is not valid. Please try again.");
            }
            if(string.IsNullOrEmpty(input.Email) || !new EmailAddressAttribute().IsValid(input.Email))
            {
                return this.Error("Invalid email.");
            }
            if(string.IsNullOrEmpty(input.Password) || input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error("Invalid password.");
            }
            if (input.ConfirmPassword != input.Password)
            {
                return this.Error("Passwords do not match.");
            }

            if (!this.userServices.IsEmailAvailable(input.Email))
            {
                return this.Error("Email already taken.");
            }

            if (!this.userServices.IsUsernameAvailable(input.Username))
            {
                return this.Error("Username already taken.");
            }

            this.userServices.Create(input.Username, input.Email, input.Password);
            return this.Redirect("/Users/Login");
        }
        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
