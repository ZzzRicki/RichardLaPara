using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Generos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Series_Generos> Series_Generos { get; set; }
    }
}
