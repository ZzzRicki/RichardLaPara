using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Series_Generos
    {
        public int Id { get; set; }
        public int IdSerie { get; set; }
        public int IdGenero { get; set; }

        public Series Series { get; set; }
        public Generos Generos { get; set; }
    }
}
