using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class Poliza
    {
        public int IdPoliza { get; set; }
        public int Numero { get; set; }
        public Productor IdProductor { get; set; }
        public Cliente IdCliente { get; set; }
        public Vehiculo IdVehiculo { get; set; }
        public Cobertura IdCobertura { get; set; }
        public DateTime VigenciaDesde { get; set; }
        public DateTime VigenciaHasta { get; set; }
        public string Patente { get; set; }
        public virtual List<Cuota> Cuotas { get; set; }

        public Poliza()
        {
            Cuotas = new List<Cuota>();
        }

        public string Estado()
        {
            string Estado = "";
            if (VigenciaHasta > DateTime.Now && VigenciaDesde < DateTime.Now)
            {
                Estado = "Vigente";
            }
            else
            {
                Estado = "Inactiva";
            }
            return Estado;
        }

        public decimal ImporteTotal()
        {
            decimal total = 0;
            foreach (Cuota cuota in Cuotas)
            {
                total = total + cuota.Importe;
            }
            return total;
        }
    }
}
