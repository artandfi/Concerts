using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Concerts.Models
{
    public class Country
    {
        public Country()
        {
            Artists = new HashSet<Artist>();
            Hosts = new HashSet<Host>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Поле необхідно заповнити")]
        [Display(Name = "Країна")]
        public string Name { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }
        public virtual ICollection<Host> Hosts { get; set; }
    }
}
