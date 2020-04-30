using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concerts.Models
{
    public class ConcertsContext : DbContext
    {
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Concert> Concerts { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Host> Hosts { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<SongArtistConcert> SongsArtistsConcerts { get; set; }

        public ConcertsContext(DbContextOptions<ConcertsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
