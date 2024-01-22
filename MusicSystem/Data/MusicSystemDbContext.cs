using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicSystem.Entities;

namespace MusicSystem.Data
{
    public class MusicSystemDbContext : DbContext
    {
        public MusicSystemDbContext(DbContextOptions<MusicSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Albums> Albums { get; set; } = default!;
        public DbSet<Users> Users { get; set; } = default!;
        public DbSet<Songs> Songs { get; set; } = default!;
        public DbSet<Artists> Artists { get; set; } = default!;
        public DbSet<Playlists> Playlists { get; set; } = default!;
        public DbSet<SongContributor> SongContributors { get; set; } = default!;
        public DbSet<PlaylistSong> PlaylistSong { get; set; } = default!;
        public MusicSystemDbContext()
        {
            this.Users = Set<Users>();
            this.Albums = Set<Albums>();
            this.Songs = Set<Songs>();
            this.Artists = Set<Artists>();
            this.Users = Set<Users>();
            this.Albums = Set<Albums>();
            this.Playlists = Set<Playlists>();
            this.SongContributors = Set<SongContributor>();
            this.PlaylistSong = Set<PlaylistSong>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MusicSystemNewDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
    }
}
