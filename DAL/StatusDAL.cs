using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    internal class StatusDAL
    {
        public List<StatusDTO> GetAll()
        {
            List<StatusDTO> lista = new List<StatusDTO>();

            using (SqlConnection conn = Konekcija.GetKonekcija())
            {
                SqlCommand cmd = new SqlCommand("SELECT IdStatus, NazivStatusa FROM Status", conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    StatusDTO status = new StatusDTO();
                    status.IdStatus = (int)reader["IdStatus"];
                    status.NazivStatusa = reader["NazivStatusa"].ToString();
                    lista.Add(status);
                }
            }
            return lista;
        }
    }
}
