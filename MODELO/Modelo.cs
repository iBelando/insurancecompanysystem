using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class Modelo
    {
        public Modelo()
        {
            this.Versiones = new List<Version>();
        }
        public Modelo(int id, string miNombre)
        {
            IdModelo = id;
            Nombre = miNombre;
        }
        public int IdModelo { get; set; }
        public string Nombre { get; set; }
        public int IdMarca { get; set; }
        public Marca Marca { get; set; }
        public virtual List<Vehiculo> Vehiculos { get; set; }
        public virtual List<Version> Versiones { get; set; }
    }
}
