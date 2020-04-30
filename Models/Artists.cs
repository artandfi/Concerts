using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Concerts.Models
{
    public class Artist
    {
        public Artist()
        {
            SongsArtistsConcerts = new HashSet<SongArtistConcert>();
        }

        public int Id { get; set; }

        public int CountryId { get; set; }

        [Required(ErrorMessage = "Поле необхідно заповнити")]
        [Display(Name = "Ім\'я")]
        public string Name { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<SongArtistConcert> SongsArtistsConcerts { get; set; }
    }
}
