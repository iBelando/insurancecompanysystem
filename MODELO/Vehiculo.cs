using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public Modelo IdModelo { get; set; }
        public Marca IdMarca { get; set; }
        public Version IdVersion { get; set; }
        public DateTime Año { get; set; }
        public virtual List<Poliza> Polizas { get; set; }

        public Vehiculo() { }
        public Vehiculo(int miId)
        {
            IdVehiculo = miId;
        }
    }
}
