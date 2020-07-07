using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class Productor
    {
        public Productor() { }
        public Productor(int miId, string miNombre)
        {
            IdProductor = miId;
            Nombre = miNombre;
        }
        public int IdProductor { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public Organizador Organizador { get; set; }
        public virtual List<Poliza> Polizas { get; set; }
    }
}
