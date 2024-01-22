using MusicSystem.Entities;

namespace MusicSystem.Entities
{
    public class PlaylistSong
    {
        public int Id { get; set; }
        public Songs? Song { get; set; }
        public int SongsId { get; set; }
        public Playlists? Playlist { get; set; }
        public int PlaylistId { get; set; }
        public DateTime TimeAdded { get; set; }

        public PlaylistSong() { }

        public PlaylistSong(int songId, int playlistId)
        {
            SongsId = songId;
            PlaylistId = playlistId;
            TimeAdded = DateTime.Now;
        }

        public PlaylistSong(Songs song, Playlists playlist, DateTime timeAdded)
        {
            Song = song;
            SongsId = song.Id;
            Playlist = playlist;
            PlaylistId = playlist.Id;
            TimeAdded = timeAdded;
        }
    }
}
