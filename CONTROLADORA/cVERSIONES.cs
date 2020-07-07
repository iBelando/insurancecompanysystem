using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTROLADORA
{
    public class cVERSIONES
    {
        private static cVERSIONES instancia;

        public static cVERSIONES obtener_instancia()
        {
            if (instancia == null)
                instancia = new cVERSIONES();
            return instancia;
        }

        DATOS.EmpresaDeSeguros oEmpresa;

        private cVERSIONES()
        {
            oEmpresa = DATOS.EmpresaDeSeguros.obtener_instancia();
        }

        public void AgregarVersion(MODELO.Version oVersion)
        {
            oEmpresa.Versiones.Add(oVersion);
            oEmpresa.SaveChanges();
        }

        public void ModificarVersion(MODELO.Version oVersion)
        {
            oEmpresa.Entry(oVersion).State = System.Data.Entity.EntityState.Modified;
            oEmpresa.SaveChanges();
        }

        public void EliminarVersion(MODELO.Version oVersion)
        {
            oEmpresa.Versiones.Remove(oVersion);
            oEmpresa.SaveChanges();
        }

        public System.Collections.IEnumerable ObtenerVersiones(string Nombre, MODELO.Modelo Modelo)
        {
            var versiones = from version in oEmpresa.Versiones.Include("Modelos").Include("Vehiculos").ToList()
                            where version.Nombre.ToLower().Contains(Nombre.ToLower()) && Modelo.IdModelo > 0 ? version.Modelos.Count(m => m.IdModelo == Modelo.IdModelo) > 0 : true
                            select new { ID = version.IdVersion, Nombre = version.Nombre, Vehiculos = version.Vehiculos.Count, Modelos = version.ObtenerNombreModelos() };
            return versiones.ToList();
        }

        public MODELO.Version ObtenerVersion(int idVersion)
        {
            return oEmpresa.Versiones.FirstOrDefault(i => i.IdVersion == idVersion);
        }

        public List<MODELO.Modelo> ObtenerModelos(bool todos = false)
        {
            List<MODELO.Modelo> Modelos = oEmpresa.Modelos.ToList();
            if (todos)
            {
                Modelos.Add(new MODELO.Modelo(0, ""));
            }
            return Modelos.ToList();
        }
    }
}
