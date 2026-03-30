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
    public class RecenzijaDAL
    {
        public List<RecenzijaDTO> GetAll(int idFilm)
        {
            List<RecenzijaDTO> lista = new List<RecenzijaDTO>();


            using (SqlConnection conn = Konekcija.GetKonekcija())
            {
                SqlCommand cmd = new SqlCommand(@"SELECT IdRecenzije, TekstRecenzije, Ocena, DatumRecenzije, IdFilm FROM Recenzija WHERE IdFilm = @IdFilm", conn);

                cmd.Parameters.AddWithValue("@IdFilm", idFilm);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RecenzijaDTO recenzija = new RecenzijaDTO();
                    recenzija.IdRecenzije = (int)reader["IdRecenzije"];
                    recenzija.TekstRecenzije = reader["TekstRecenzije"].ToString();
                    recenzija.Ocena = (int)reader["Ocena"];
                    recenzija.DatumRecenzije = (DateTime)reader["DatumRecenzije"];
                    recenzija.IdFilm = (int)reader["IdFilm"];
                    lista.Add(recenzija);
                }
            }
            return lista;
        }

        public void Insert(RecenzijaDTO recenzija)
        {
            using(SqlConnection conn = Konekcija.GetKonekcija())
            {
                SqlCommand cmd = new SqlCommand("sp_DodajRecenziju", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TekstRecenzije", recenzija.TekstRecenzije);
                cmd.Parameters.AddWithValue("@Ocena", recenzija.Ocena);
                cmd.Parameters.AddWithValue("@DatumRecenzije", recenzija.DatumRecenzije);
                cmd.Parameters.AddWithValue("@IdFilm", recenzija.IdFilm);

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
                    throw new Exception("Greška pri dodavanju recenzije: " + ex.Message);
                }
            }
        }

        public void Update(RecenzijaDTO recenzija)
        {
            using(SqlConnection conn = Konekcija.GetKonekcija())
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE Recenzija SET TekstRecenzije = @TekstRecenzije, Ocena = @Ocena, DatumRecenzije = @DatumRecenzije WHERE IdRecenzije = @IdRecenzije", conn);
                cmd.Parameters.AddWithValue("@TekstRecenzije", recenzija.TekstRecenzije);
                cmd.Parameters.AddWithValue("@Ocena", recenzija.Ocena);
                cmd.Parameters.AddWithValue("@DatumRecenzije", recenzija.DatumRecenzije);
                cmd.Parameters.AddWithValue("@IdRecenzije", recenzija.IdRecenzije);

                conn.Open();

                SqlTransaction transakcija = conn.BeginTransaction();
                cmd.Transaction = transakcija;

                try
                {
                    cmd.ExecuteNonQuery();
                    transakcija.Commit();
                }
                catch(Exception ex)
                {
                    transakcija.Rollback();
                    throw new Exception("Greška pri izmeni recenzije: " + ex.Message);
                }
            }
        }

        public void Delete(int idRecenzije)
        {
            using (SqlConnection conn = Konekcija.GetKonekcija())
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Recenzija WHERE IdRecenzije = @IdRecenzije", conn);
                cmd.Parameters.AddWithValue("@IdRecenzije", idRecenzije);

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
                    throw new Exception("Greška pri brisanju recenzije: " + ex.Message);
                }
            }
        }
    }
}
