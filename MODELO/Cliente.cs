using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public int CUIL { get; set; }
        public int CUIT { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
        public int Celular { get; set; }
        public string Direccion { get; set; }
        public Localidad IdLocalidad { get; set; } 
        public virtual List<Poliza> Polizas { get; set; }

        public Cliente() { }
        public Cliente (int miID, string miNombre)
        {
            Nombre = miNombre;
            IdCliente = miID;
        }

        public int CalcularPoliza()
        {
            int total;
            if (Polizas == null)
                total = 0;
            else
                total = Polizas.Count();
            return total;
        }
    }
}
