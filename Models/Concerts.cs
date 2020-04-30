using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Concerts.Models
{
    public class Concert
    {
        private const string ERR_REQ = "Поле необхідно заповнити";

        public Concert()
        {
            SongArtistConcerts = new HashSet<SongArtistConcert>();
        }

        public int Id { get; set; }
        
        public int HostId { get; set; }

        [Required(ErrorMessage = ERR_REQ)]
        [Display(Name = "Назва")]
        public string Name { get; set; }

        [Required(ErrorMessage = ERR_REQ)]
        [Display(Name = "Місце проведення")]
        public string Location { get; set; }

        [Required(ErrorMessage = ERR_REQ)]
        [Display(Name = "Ціна")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = ERR_REQ)]
        [Display(Name = "Залишилось квитків")]
        public int TicketsLeft { get; set; }

        [Required(ErrorMessage = ERR_REQ)]
        [Display(Name = "Дата проведення")]
        public DateTime Date { get; set; }
        
        public virtual Host Host { get; set; }

        public virtual ICollection<SongArtistConcert> SongArtistConcerts { get; set; }
    }
}
