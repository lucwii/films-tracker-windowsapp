using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biznis
{
    public class ZanrBiznis
    {
        private ZanrDAL zanrDAL = new ZanrDAL();

        public List<ZanrDTO> GetAll()
        {
            return zanrDAL.GetAll();
        }

        public void Insert(ZanrDTO zanr)
        {
            Validiraj(zanr);
            zanrDAL.Insert(zanr);
        }

        public void Update(ZanrDTO zanr)
        {
            Validiraj(zanr);
            zanrDAL.Update(zanr);
        }

        public void Delete(int idZanr)
        {
            if(zanrDAL.ImaFilmove(idZanr))
            {
                throw new Exception("Nije moguce obrisati zanr koji ima povezane filmove!");
            }

            zanrDAL.Delete(idZanr);
        }

        private void Validiraj(ZanrDTO zanr)
        {
            if(string.IsNullOrWhiteSpace(zanr.NazivZanra))
            {
                throw new Exception("Naziv zanra je obavezan");
            }

            if(zanr.NazivZanra.Length > 100)
            {
                throw new Exception("Naziv zanra ne sme biti duzi od 100 karaktera");
            }
        }
    }
}
