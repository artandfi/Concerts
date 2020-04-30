using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Concerts.Models
{
    public class Song
    {
        public Song()
        {
            SongsArtistsConcerts = new HashSet<SongArtistConcert>();    
        }

        public int Id { get; set; }
        
        public int GenreId { get; set; }

        [Required(ErrorMessage = "Поле необхідно заповнити")]
        [Display(Name = "Композиція")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле необхідно заповнити")]
        [Display(Name = "Лейбл")]
        public string Label { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual ICollection<SongArtistConcert> SongsArtistsConcerts { get; set; }
    }
}
