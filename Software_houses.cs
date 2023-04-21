using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("software_houses")]
    public class Software_house
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Tax_id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Videogame> Videogames { get; set; }

        public Software_house(long id, string name, string tax_id, string city, string country)
        {
            Id = id;
            Name = name;
            Tax_id = tax_id;
            City = city;
            Country = country;
        }
    }
}
