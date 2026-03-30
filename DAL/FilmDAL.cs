using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FilmDAL
    {
        public List<FilmDTO> GetAll(int idZanr)
        {
            List<FilmDTO> lista = new List<FilmDTO>();

            using (SqlConnection conn = Konekcija.GetKonekcija())
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT f.IdFilm, f.Naziv, f.DatumGledanja, 
                             f.IdZanr, f.IdStatus, s.NazivStatusa
                      FROM Film f
                      INNER JOIN Status s ON f.IdStatus = s.IdStatus
                      WHERE f.IdZanr = @IdZanr", conn);

                cmd.Parameters.AddWithValue("@IdZanr", idZanr);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    FilmDTO film = new FilmDTO();
                    film.IdFilm = (int)reader["IdFilm"];
                    film.Naziv = reader["Naziv"].ToString();
                    film.DatumGledanja = (DateTime)reader["DatumGledanja"];
                    film.IdZanr = (int)reader["IdZanr"];
                    film.IdStatus = (int)reader["IdStatus"];
                    film.NazivStatusa = reader["NazivStatusa"].ToString();
                    lista.Add(film);
                }
            }
            return lista;
        }


        public void Insert(FilmDTO film)
        {
            using(SqlConnection conn = Konekcija.GetKonekcija())
            {
                SqlCommand cmd = new SqlCommand("sp_DodajFilm", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Naziv", film.Naziv);
                cmd.Parameters.AddWithValue("@DatumGledanja", film.DatumGledanja);
                cmd.Parameters.AddWithValue("@IdZanr", film.IdZanr);
                cmd.Parameters.AddWithValue("@IdStatus", film.IdStatus);

                conn.Open();

                SqlTransaction transakcija = conn.BeginTransaction();
                cmd.Transaction = transakcija;

                try
                {
                    cmd.ExecuteNonQuery();
                    transakcija.Commit();
                }
                catch (Exception ex)
                {
                    transakcija.Rollback();
                    throw new Exception("Greška pri dodavanju filma: " + ex.Message);
                }
            }
        }

        public void Update(FilmDTO film)
        {
            using(SqlConnection conn = Konekcija.GetKonekcija())
            {
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE Film SET Naziv = @Naziv, DatumGledanja = @DatumGledanja, IdStatus = @IdStatus WHERE IdFilm = @IdFilm", conn);

                cmd.Parameters.AddWithValue("@Naziv", film.Naziv);
                cmd.Parameters.AddWithValue("@DatumGledanja", film.DatumGledanja);
                cmd.Parameters.AddWithValue("@IdStatus", film.IdStatus);
                cmd.Parameters.AddWithValue("@IdFilm", film.IdFilm);

                conn.Open();

                SqlTransaction transakcija = conn.BeginTransaction();
                cmd.Transaction = transakcija;

                try
                {
                    cmd.ExecuteNonQuery();
                    transakcija.Commit();
                }
                catch (Exception ex)
                {
                    transakcija.Rollback();
                    throw new Exception("Greška pri izmeni filma: " + ex.Message);
                }
            }
        }

        public void Delete(int idFilm)
        {
            using(SqlConnection conn = Konekcija.GetKonekcija())
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Film WHERE IdFilm = @IdFilm", conn);
                cmd.Parameters.AddWithValue("@IdFilm", idFilm);

                conn.Open();

                SqlTransaction transakcija = conn.BeginTransaction();
                cmd.Transaction = transakcija;

                try
                {
                    cmd.ExecuteNonQuery();
                    transakcija.Commit();
                }
                catch (Exception ex)
                {
                    transakcija.Rollback();
                    throw new Exception("Greška pri brisanju filma: " + ex.Message);
                }
            }
        }

        public bool ImaRecenzije(int idFilm)
        {
            using (SqlConnection conn = Konekcija.GetKonekcija())
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Recenzija WHERE IdFilm = @IdFilm", conn);
                cmd.Parameters.AddWithValue("@IdFilm", idFilm);

                conn.Open();
                int broj = (int)cmd.ExecuteScalar();
                return broj > 0;
            }
        }
    }
}
