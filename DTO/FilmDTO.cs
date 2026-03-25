using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class FilmDTO
    {
        public int IdFilm { get; set; }
        public string Naziv { get; set; }
        public DateTime DatumGledanja { get; set; }
        public int IdZanr { get; set; }
        public int IdStatus { get; set; }

        // Ovo dodajemo da bi u DataGridView-u pisalo ime statusa
        // umesto samo ID broja
        public string NazivStatusa { get; set; }
    }
}
