using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class Version
    {
        public int IdVersion { get; set; }
        public string Nombre { get; set; }
        public List<Modelo> Modelos { get; set; }
        public List<Vehiculo> Vehiculos { get; set; }

        public Version()
        {
            this.Modelos = new List<Modelo>();
        }

        public string ObtenerNombreModelos()
        {
            string mensaje = "";
            if (Modelos.Count > 0)
            {
                foreach (Modelo modelo in Modelos)
                {
                    mensaje += modelo.Nombre + " ";
                }
            }
            else
            {
                mensaje = "No hay modelos asignados";
            }
            return mensaje;
        }
    }
}
