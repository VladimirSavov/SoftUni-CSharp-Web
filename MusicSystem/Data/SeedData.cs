using MusicSystem.Data;
using MusicSystem.Entities;
using Microsoft.EntityFrameworkCore;
using MusicSystem.Data;

namespace MusicSystem.Models
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var context = new MusicSystemDbContext(serviceProvider.GetRequiredService<DbContextOptions<MusicSystemDbContext>>());

            context.Database.EnsureDeleted();
            context.Database.Migrate();

            //Albums Album1 = new Albums("Playlist Vol. 85");
            //Albums Album2 = new Albums("Euromach 1");
            //Albums Album3 = new Albums("Eurobeat Flash Vol. 14");
            //Albums Album4 = new Albums("Maharaja Night Hi-NRG Revolution Vol. 17");
            //Albums Album5 = new Albums("The Best Of Super Eurobeat 2022");
            //Albums Album6 = new Albums("Playlist Vol. 175");
            //Albums Album7 = new Albums("Playlist Vol. 101");

            //if (!context.Albums.Any())
            //{
            //    context.Albums.Add(Album1);
            //    context.Albums.Add(Album2);
            //    context.Albums.Add(Album3);
            //    context.Albums.Add(Album4);
            //    context.Albums.Add(Album5);
            //    context.Albums.Add(Album6);
            //    context.Albums.Add(Album7);

            //    context.SaveChanges();
            //}

            //Artists Artist1 = new Artists("Toby Ash");
            //Artists Artist2 = new Artists("Меди");
            //Artists Artist3 = new Artists("Domino");
            //Artists Artist4 = new Artists("Sandy Bee");
            //Artists Artist5 = new Artists("Marko Polo");
            //Artists Artist6 = new Artists("Niko");
            //Artists Artist7 = new Artists("Jungle Bill");
            //Artists Artist8 = new Artists("Галена");
            //Artists Artist9 = new Artists("Jeff Driller");
            //Artists Artist10 = new Artists("Black Power");
            //Artists Artist11 = new Artists("Mega NRG Man");
            //Artists Artist12 = new Artists("Max Coveri");

            //if (!context.Artists.Any())
            //{

            //    context.Artists.Add(Artist1);
            //    context.Artists.Add(Artist2);
            //    context.Artists.Add(Artist3);
            //    context.Artists.Add(Artist4);
            //    context.Artists.Add(Artist5);
            //    context.Artists.Add(Artist6);
            //    context.Artists.Add(Artist7);
            //    context.Artists.Add(Artist8);
            //    context.Artists.Add(Artist9);
            //    context.Artists.Add(Artist10);
            //    context.Artists.Add(Artist11);
            //    context.Artists.Add(Artist12);

            //    context.SaveChanges();
            //}

            //Songs Song1 = new Songs("К'ъв съм як", 345, Album2);
            //Songs Song2 = new Songs("Rain", 274, Album6);
            //Songs Song3 = new Songs("Thunder Boy", 315, Album5);
            //Songs Song4 = new Songs("Made Of Fire", 340, Album2);
            //Songs Song5 = new Songs("Живей, мило мое", 363, Album2);
            //Songs Song6 = new Songs("Shake Me Up", 337, Album2);
            //Songs Song7 = new Songs("ПЕСЕН ЗА НАРОДА", 373, Album2);
            //Songs Song8 = new Songs("What's Your Game", 337, Album3);
            //Songs Song9 = new Songs("Take My Hammer", 352, Album3);
            //Songs Song10 = new Songs("Give Me Your Love", 333, Album4);
            //Songs Song11 = new Songs("Are You Ready For Me", 317, Album4);
            //Songs Song12 = new Songs("Rock You Baby", 313, Album1);
            //Songs Song13 = new Songs("Take Me Like A Wild Boy", 333, Album1);
            //Songs Song14 = new Songs("Flame On The Fire", 382, Album4);
            //Songs Song15 = new Songs("Не си ме давай", 382, Album6);
            //Songs Song16 = new Songs("Go Go Where You Wanna Go Go", 272, Album6);
            //Songs Song17 = new Songs("Rock Me", 264, Album6);
            //Songs Song18 = new Songs("Running in the 90s", 333, Album1);
            //Songs Song19 = new Songs("Supercar", 350, Album7);
            //Songs Song20 = new Songs("Speedway", 317, Album7);

            //if (!context.Songs.Any())
            //{
            //    context.Songs.Add(Song1);
            //    context.Songs.Add(Song2);
            //    context.Songs.Add(Song3);
            //    context.Songs.Add(Song4);
            //    context.Songs.Add(Song5);
            //    context.Songs.Add(Song6);
            //    context.Songs.Add(Song7);
            //    context.Songs.Add(Song8);
            //    context.Songs.Add(Song9);
            //    context.Songs.Add(Song10);
            //    context.Songs.Add(Song11);
            //    context.Songs.Add(Song12);
            //    context.Songs.Add(Song13);
            //    context.Songs.Add(Song14);
            //    context.Songs.Add(Song15);
            //    context.Songs.Add(Song16);
            //    context.Songs.Add(Song17);
            //    context.Songs.Add(Song18);
            //    context.Songs.Add(Song19);
            //    context.Songs.Add(Song20);

            //    context.SaveChanges();
            //}


            //// Compacted code, with help from Samantha
            //SongContributor[] SConts = new SongContributor[]
            //{
            //new SongContributor(Artist1, Song1, "Artist"),
            //new SongContributor(Artist2, Song2, "Artist"),
            //new SongContributor(Artist2, Song3, "Artist"),
            //new SongContributor(Artist6, Song4, "Artist"),
            //new SongContributor(Artist5, Song5, "Artist"),
            //new SongContributor(Artist7, Song6, "Artist"),
            //new SongContributor(Artist7, Song7, "Artist"),
            //new SongContributor(Artist8, Song8, "Artist"),
            //new SongContributor(Artist9, Song9, "Artist"),
            //new SongContributor(Artist4, Song10, "Artist"),
            //new SongContributor(Artist10, Song11, "Artist"),
            //new SongContributor(Artist10, Song12, "Artist"),
            //new SongContributor(Artist11, Song13, "Artist"),
            //new SongContributor(Artist11, Song14, "Artist"),
            //new SongContributor(Artist9, Song15, "Artist"),
            //new SongContributor(Artist3, Song16, "Artist"),
            //new SongContributor(Artist11, Song17, "Artist"),
            //new SongContributor(Artist12, Song18, "Artist"),
            //new SongContributor(Artist12, Song19, "Artist"),
            //new SongContributor(Artist6, Song20, "Artist")
            //};

            //if (!context.SongContributors.Any())
            //{
            //    foreach (SongContributor contributor in SConts)
            //    {
            //        context.Add(contributor);
            //    }

            //    context.SaveChanges();
            //}

            //Playlists playlist1 = new Playlists("Playlist to DANCE to");
            //Playlists playlist2 = new Playlists("Playlist to DRIVE to");
            //Playlists playlist3 = new Playlists("Playlist to CHILL to");

            //if (!context.Playlists.Any())
            //{
            //    context.Playlists.Add(playlist1);
            //    context.Playlists.Add(playlist2);
            //    context.Playlists.Add(playlist3);

            //    context.SaveChanges();
            //}

            //PlaylistSong plSong1 = new PlaylistSong(Song9, playlist1, DateTime.Now);
            //PlaylistSong plSong2 = new PlaylistSong(Song4, playlist2, DateTime.Now);
            //PlaylistSong plSong3 = new PlaylistSong(Song2, playlist2, DateTime.Now);
            //PlaylistSong plSong4 = new PlaylistSong(Song1, playlist3, DateTime.Now);

            //if (!context.PlaylistSong.Any())
            //{
            //    context.PlaylistSong.Add(plSong1);
            //    context.PlaylistSong.Add(plSong2);
            //    context.PlaylistSong.Add(plSong3);
            //    context.PlaylistSong.Add(plSong4);

            //    context.SaveChanges();
            //}

            //await context.SaveChangesAsync();
        }
    }
}