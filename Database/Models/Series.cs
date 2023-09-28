using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Series
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ImagenPortada { get; set; }
        public string Uri { get; set; }
        public int IdProductora { get; set; }

        public ICollection<Series_Generos> Series_Generos { get; set; }
        public Productora Productora { get; set; }
    }
}
