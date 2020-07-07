using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class Marca
    {
        public Marca() { }
        public Marca(int id, string miNombre)
        {
            IdMarca = id;
            Nombre = miNombre;
        }
        public int IdMarca { get; set; }
        public string Nombre { get; set; }
        public virtual List<Modelo> Modelos { get; set; }
        public virtual List<Vehiculo> Vehiculos { get; set; }
    }
}
