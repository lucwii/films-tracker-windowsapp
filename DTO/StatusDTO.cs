using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StatusDTO
    {
        public int IdStatus { get; set; }
        public string NazivStatusa { get; set; }

        public override string ToString()
        {
            return NazivStatusa;
        }
    }
}
