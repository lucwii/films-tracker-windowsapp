using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biznis
{
    public class FilmBiznis
    {
        private FilmDAL filmDAL = new FilmDAL();

        public List<FilmDTO> GetAll(int idZanr)
        {
            return filmDAL.GetAll(idZanr);
        }

        public void Insert(FilmDTO film)
        {
            Validiraj(film);
            filmDAL.Insert(film);
        }

        public void Update(FilmDTO film)
        {
            Validiraj(film);
            filmDAL.Update(film);
        }

        public void Delete(int idFilm)
        {
            if(filmDAL.ImaRecenzije(idFilm))
            {
                throw new Exception("Nije moguće obrisati film koji ima povezane recenzije!");
            }

            filmDAL.Delete(idFilm);
        }

        private void Validiraj(FilmDTO film)
        {
            if (string.IsNullOrWhiteSpace(film.Naziv))
                throw new Exception("Naziv filma je obavezan!");

            if (film.Naziv.Length > 200)
                throw new Exception("Naziv filma ne sme biti duži od 200 karaktera!");

            if (film.DatumGledanja == DateTime.MinValue)
                throw new Exception("Datum gledanja je obavezan!");

            if (film.IdStatus <= 0)
                throw new Exception("Status filma je obavezan!");
        }
    }
}
