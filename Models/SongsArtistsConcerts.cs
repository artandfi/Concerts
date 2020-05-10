using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Concerts.Models
{
    public class SongArtistConcert
    {
        public int Id { get; set; }

        public int? SongId { get; set; }

        public int? ArtistId { get; set; }

        public int? ConcertId { get; set; }

        [ForeignKey("SongId")]
        public virtual Song Song { get; set; }

        [ForeignKey("ArtistId")]
        public virtual Artist Artist { get; set; }

        [ForeignKey("ConcertId")]
        public virtual Concert Concert { get; set; }
    }
}
