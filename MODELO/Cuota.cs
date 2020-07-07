using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class Cuota
    {
        public int IdCuota { get; set; }
        public decimal Importe { get; set; }
        public int NroCuota { get; set; }
        public string Estado { get; set; }

        public void EstadoCuota()
        {
            this.Estado = "Pendiente";
            if (Importe <= 0)
            {
                this.Estado = "Pago";
            }
        }
    }
}
