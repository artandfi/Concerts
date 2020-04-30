using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Concerts.Models
{
    public class Host
    {
        public Host()
        {
            Concerts = new HashSet<Concert>();
        }

        public int Id { get; set; }
        
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Поле необхідно заповнити")]
        [Display(Name = "Організатор")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле необхідно заповнити")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Concert> Concerts { get; set; }
    }
}
