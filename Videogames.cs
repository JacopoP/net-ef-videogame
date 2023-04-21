using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("videogames")]
   public class Videogame
    {
        [Key]
        public long Id { get; set; } 
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime Release_date { get; set; }
        public long Software_houseID { get; set; }
        public Software_house Software_house { get; set; }

        public Videogame(long id, string name, string overview, DateTime release_date)
        {
            Id = id;
            Name = name;
            Overview = overview;
            Release_date = release_date;
        }
    }
}
