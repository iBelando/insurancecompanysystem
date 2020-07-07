using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class Cobertura
    {
        public Cobertura() { }
        public Cobertura (int miId, string miNombre)
        {
            IdCobertura = miId;
            Nombre = miNombre;
        }
        public int IdCobertura { get; set; }
        public string Nombre { get; set; }
        public int NroCuotas { get; set; }
        public decimal ImporteCuota { get; set; }
        public virtual List<Poliza> Polizas { get; set; }
    }
}
