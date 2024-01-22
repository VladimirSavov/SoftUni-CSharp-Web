namespace MusicSystem.Entities
{
    public class Users
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public Users() { }
        public Users(string username)
        {
            Username = username;
        }
    }
}
