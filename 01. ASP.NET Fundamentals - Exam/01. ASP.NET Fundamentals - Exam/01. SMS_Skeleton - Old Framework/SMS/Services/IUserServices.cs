using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Services
{
    public interface IUserServices
    {
        string GetUserId(string username, string password);

        void Create(string username, string email, string password);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email);
    }
}
