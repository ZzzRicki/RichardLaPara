using Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SerieViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debes Colocar el nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debes Colocar la imagen")]
        public string ImagenPortada { get; set; }
        [Required(ErrorMessage = "Debes Colocar la Uri")]
        public string Uri { get; set; }
        [Required(ErrorMessage = "Debes Colocar la productora")]
        public int IdProductora { get; set; }
        public List<Series> data { get; set; }
    }
}
