using MusicSystem.Entities;

namespace MusicSystem.Entities
{
    public class SongContributor
    {
        public int Id { get; set; }
        public Artists? Artist { get; set; }
        public int ArtistId { get; set; }
        public Songs? Song { get; set; }
        public int SongId { get; set; }
        public string Role { get; set; }

        public SongContributor() { }

        public SongContributor(Artists artist, Songs song, string role)
        {
            Artist = artist;
            ArtistId = artist.Id;
            Song = song;
            SongId = song.Id;
            Role = role;
        }
    }
}
