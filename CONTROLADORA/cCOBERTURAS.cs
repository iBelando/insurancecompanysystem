using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTROLADORA
{
    public class cCOBERTURAS
    {
        private static cCOBERTURAS instancia;

        public static cCOBERTURAS obtener_instancia()
        {
            if (instancia == null)
                instancia = new cCOBERTURAS();
            return instancia;
        }

        DATOS.EmpresaDeSeguros oEmpresa;

        private cCOBERTURAS()
        {
            oEmpresa = DATOS.EmpresaDeSeguros.obtener_instancia();
        }

        public void AgregarCobertura (MODELO.Cobertura oCobertura)
        {
            oEmpresa.Coberturas.Add(oCobertura);
            oEmpresa.SaveChanges();
        }

        public void ModificarCobertura (MODELO.Cobertura oCobertura)
        {
            oEmpresa.Entry(oCobertura).State = System.Data.Entity.EntityState.Modified;
            oEmpresa.SaveChanges();
        }

        public void EliminarCobertura (MODELO.Cobertura oCobertura)
        {
            oEmpresa.Coberturas.Remove(oCobertura);
            oEmpresa.SaveChanges();
        }

        public System.Collections.IEnumerable ObtenerCoberturas (string nombreCobertura)
        {
            var coberturas = from cobertura in oEmpresa.Coberturas.ToList()
                             where cobertura.Nombre.ToLower().Contains(nombreCobertura.ToLower())
                             select new { ID = cobertura.IdCobertura, Nombre = cobertura.Nombre, NroCuotas = cobertura.NroCuotas, Importe = cobertura.ImporteCuota };
        return coberturas.ToList();
        }

        public MODELO.Cobertura ObtenerCobertura (int idCobertura)
        {
            return oEmpresa.Coberturas.FirstOrDefault(d => d.IdCobertura == idCobertura);
        }
    }
}
