using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class Localidad
    {
        public Localidad() { }
        public Localidad(int miId, int miCodPostal, string miNombre)
        {
            IdLocalidad = miId;
            CodPostal = miCodPostal;
            Nombre = miNombre;
        }
        public int IdLocalidad { get; set; }
        public string Nombre { get; set; }
        public int CodPostal { get; set; }
        public virtual List<Cliente> Clientes { get; set; }

        public int CantidadClientes()
        {
            int ClientesTotal;
            if (Clientes == null)
                ClientesTotal = 0;
            else
                ClientesTotal = Clientes.Count;
            return ClientesTotal;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
