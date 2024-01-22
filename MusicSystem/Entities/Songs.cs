using MusicSystem.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSystem.Entities
{
    public class Songs
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public Albums? Album { get; set; }

        public HashSet<SongContributor> SongContributors { get; set; } = new HashSet<SongContributor>();
        public HashSet<PlaylistSong> PlaylistSong { get; set; } = new HashSet<PlaylistSong>();
        [ForeignKey("OwnerId")]
        public Users Owner { get; set; }

        public Songs() { }

        public Songs(string title, int duration, Albums album)
        {
            Title = title;
            Duration = duration;
            Album = album;
        }
    }
}
