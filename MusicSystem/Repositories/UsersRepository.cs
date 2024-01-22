using System.Collections.Generic;
using MusicSystem.Entities;

namespace MusicSystem.Repositories
{
    public class UsersRepository
    {
        public static List<Users> Items { get; set; }
        static UsersRepository()
        {
            Items = new List<Users>() {
        new Users() {
          Id = 1,
          Username = "Test",
          Password = "Test",
        },
        new Users()
        {
          Id = 2,
          Username= "Vesi",
          Password = "Vesi",
        },
        new Users()
        {
          Id = 3,
          Username= "admin",
          Password = "admin",
        },
        new Users()
        {
          Id = 4,
          Username= "admin15",
          Password = "admin15",
        },
      };
        }
    }
}
