using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concerts.Models
{
    public class SongArtistConcert
    {
        public int Id { get; set; }

        public int SongId { get; set; }

        public int ArtistId { get; set; }

        public int ConcertId { get; set; }

        public virtual Song Song { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual Concert Concert { get; set; }
    }
}
