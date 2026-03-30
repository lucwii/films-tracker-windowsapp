using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RecenzijaDTO
    {
        public int IdRecenzije { get; set; }
        public string TekstRecenzije { get; set; }
        public int Ocena { get; set; }
        public DateTime DatumRecenzije { get; set; }
        public int IdFilm { get; set; }
    }
}
