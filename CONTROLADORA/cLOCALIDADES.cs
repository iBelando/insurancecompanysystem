using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTROLADORA
{
    public class cLOCALIDADES
    {
        private static cLOCALIDADES instancia;

        public static cLOCALIDADES obtener_instancia()
        {
            if (instancia == null)
                instancia = new cLOCALIDADES();
            return instancia;
        }

        DATOS.EmpresaDeSeguros oEmpresa;

        private cLOCALIDADES()
        {
            oEmpresa = DATOS.EmpresaDeSeguros.obtener_instancia();
        }

        public void AgregarLocalidad(MODELO.Localidad oLocalidad)
        {
            oEmpresa.Localidades.Add(oLocalidad);
            oEmpresa.SaveChanges();
        }

        public void ModificarLocalidad(MODELO.Localidad oLocalidad)
        {
            oEmpresa.Entry(oLocalidad).State = System.Data.Entity.EntityState.Modified;
            oEmpresa.SaveChanges();
        }

        public void EliminarLocalidad(MODELO.Localidad oLocalidad)
        {
            oEmpresa.Localidades.Remove(oLocalidad);
            oEmpresa.SaveChanges();
        }

        public System.Collections.IEnumerable ObtenerLocalidades(string nombreLocalidad)
        {
            var localidades = from localidad in oEmpresa.Localidades.ToList()
                              where localidad.Nombre.ToLower().Contains(nombreLocalidad.ToLower())
                              select new { ID = localidad.IdLocalidad, Nombre = localidad.Nombre, CodigoPostal = localidad.CodPostal };
            return localidades.ToList();
        }

        public MODELO.Localidad ObtenerLocalidad(int idLocalidad)
        {
            return oEmpresa.Localidades.FirstOrDefault(d => d.IdLocalidad == idLocalidad);
        }
    }
}
