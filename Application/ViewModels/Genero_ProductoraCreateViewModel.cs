using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class Genero_ProductoraCreateViewModel
    {
        public List<GeneroViewModel> Genero { get; set; }
        public List<ProductoraViewModel> Productora { get; set; }
    }
}
