using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biznis
{
    public class RecenzijaBiznis
    {
        private RecenzijaDAL recenzijaDAL = new RecenzijaDAL();

        public List<RecenzijaDTO> GetAll(int idFilm)
        {
            return recenzijaDAL.GetAll(idFilm);
        }

        public void Insert(RecenzijaDTO recenzija)
        {
            Validiraj(recenzija);
            recenzijaDAL.Insert(recenzija);
        }

        public void Update(RecenzijaDTO recenzija)
        {
            Validiraj(recenzija);
            recenzijaDAL.Update(recenzija);
        }

        public void Delete(int idRecenzija)
        {
            recenzijaDAL.Delete(idRecenzija);
        }

        private void Validiraj(RecenzijaDTO recenzija)
        {
            if (string.IsNullOrWhiteSpace(recenzija.TekstRecenzije))
                throw new Exception("Tekst recenzije je obavezan!");

            if (recenzija.Ocena < 1 || recenzija.Ocena > 10)
                throw new Exception("Ocena mora biti između 1 i 10!");

            if (recenzija.DatumRecenzije == DateTime.MinValue)
                throw new Exception("Datum recenzije je obavezan!");
        }
    }
}
