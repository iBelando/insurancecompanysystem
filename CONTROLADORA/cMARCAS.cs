using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTROLADORA
{
    public class cMARCAS
    {
        private static cMARCAS instancia;

        public static cMARCAS obtener_instancia()
        {
            if (instancia == null)
                instancia = new cMARCAS();
            return instancia;
        }

        DATOS.EmpresaDeSeguros oEmpresa;

        private cMARCAS()
        {
            oEmpresa = DATOS.EmpresaDeSeguros.obtener_instancia();
        }

        public void AgregarMarca (MODELO.Marca oMarca)
        {
            oEmpresa.Marcas.Add(oMarca);
            oEmpresa.SaveChanges();
        }

        public void ModificarMarca (MODELO.Marca oMarca)
        {
            oEmpresa.Entry(oMarca).State = System.Data.Entity.EntityState.Modified;
            oEmpresa.SaveChanges();
        }

        public void EliminarMarca (MODELO.Marca oMarca)
        {
            oEmpresa.Marcas.Remove(oMarca);
            oEmpresa.SaveChanges();
        }

        public System.Collections.IEnumerable ObtenerMarcas(string nombreMarca)
        {
            var marcas = from marca in oEmpresa.Marcas.ToList()
                            where marca.Nombre.ToLower().Contains(nombreMarca.ToLower())
                            select new { IdMarca = marca.IdMarca, Nombre = marca.Nombre };
            return marcas.ToList();
        }

        public MODELO.Marca ObtenerMarca(int idMarca)
        {
            return oEmpresa.Marcas.FirstOrDefault(d => d.IdMarca == idMarca);
        }
    }
}
