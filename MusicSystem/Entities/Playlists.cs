using Microsoft.Identity.Client;
using MusicSystem.Entities;

namespace MusicSystem.Entities
{
    public class Playlists
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public HashSet<PlaylistSong> PlaylistSong { get; set; } = new HashSet<PlaylistSong>();

        public Playlists() { }

        public Playlists(string name)
        {
            Name = name;
        }
    }
}

