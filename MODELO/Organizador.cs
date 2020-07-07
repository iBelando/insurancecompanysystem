using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class Organizador
    {
        public Organizador() { }
        public Organizador(int miID, string miNombre)
        {
            IdOrganizador = miID;
            Nombre = miNombre;
            Productores = null;
        }

        public int IdOrganizador { get; set; }
        public string Nombre { get; set; }
        public  virtual List<Productor> Productores { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public string ObtenerNombres()
        {
            string nombres = "";
            if (Productores.Count > 0)
            {
                foreach (Productor productor in this.Productores)
                {
                    nombres += productor.Nombre + " ";
                }
            }
            else
            {
                nombres = "No tiene ningún productor a cargo!";
            }
            return nombres;
        }
    }
}
