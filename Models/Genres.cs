using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Concerts.Models
{
    public class Genre
    {
        public Genre()
        {
            Songs = new HashSet<Song>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Поле необхідно заповнити")]
        [Display(Name = "Жанр")]
        public string Name { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
