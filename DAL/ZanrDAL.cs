using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    internal class ZanrDAL
    {
        public List<ZanrDTO> GetAll()
        {
            List<ZanrDTO> lista = new List<ZanrDTO>();

            using(SqlConnection conn = Konekcija.GetKonekcija())
            {
                SqlCommand cmd = new SqlCommand("SELECT IdZanr, NazivZanra FROM Zanr", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    ZanrDTO zanr = new ZanrDTO();
                    zanr.idZanr = (int)reader["IdZanr"];
                    zanr.NazivZanra = reader["NazivZanra"].ToString();
                    lista.Add(zanr);
                }
            }
            return lista;
        } 


        public void Insert(ZanrDTO zanr)
        {
            using(SqlConnection conn = Konekcija.GetKonekcija())
            {
                SqlCommand cmd = new SqlCommand("sp_DodajZanr", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NazivZanra", zanr.NazivZanra);

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
                    throw new Exception("Greska pri dodavanju zanra" + ex.Message);
                }
            }
        }


        public void Update(ZanrDTO zanr)
        {
            using(SqlConnection conn = Konekcija.GetKonekcija())
            {
                SqlCommand cmd = new SqlCommand("UPDATE Zanr SET NazivZanra = @NazivZanra WHERE IdZanr = @IdZanr", conn);
                cmd.Parameters.AddWithValue("@NazivZanra", zanr.NazivZanra);
                cmd.Parameters.AddWithValue("IdZanr", zanr.idZanr);

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
                    throw new Exception("Greška pri izmeni žanra: " + ex.Message);
                }
            }
        }


        public void Delete(int IdZanr)
        {
            using (SqlConnection conn = Konekcija.GetKonekcija())
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Zanr WHERE IdZanr = @IdZanr", conn);
                cmd.Parameters.AddWithValue("@IdZanr", IdZanr);

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
                    throw new Exception("Greska pri brisanju zanra:" + ex.Message);
                }
            }
        }

        public bool ImaFilmove(int idZanr)
        {
            using (SqlConnection conn = Konekcija.GetKonekcija())
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Film WHERE IdZanr = @IdZanr", conn);
                cmd.Parameters.AddWithValue("@IdZanr", idZanr);

                conn.Open();
                int broj = (int)cmd.ExecuteScalar();
                return broj > 0;
            }
        }
    }
}
