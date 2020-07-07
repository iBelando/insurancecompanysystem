using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTROLADORA
{
    public class cORGANIZADORES
    {
        private static cORGANIZADORES instancia;

        public static cORGANIZADORES obtener_instancia()
        {
            if (instancia == null)
                instancia = new cORGANIZADORES();
            return instancia;
        }

        DATOS.EmpresaDeSeguros oEmpresa;

        private cORGANIZADORES()
        {
            oEmpresa = DATOS.EmpresaDeSeguros.obtener_instancia();
        }

        public void AgregarOrganizador (MODELO.Organizador oOrganizador)
        {
            oEmpresa.Organizadores.Add(oOrganizador);
            oEmpresa.SaveChanges();
        }

        public void ModificarOrganizador (MODELO.Organizador oOrganizador)
        {
            oEmpresa.Entry(oOrganizador).State = System.Data.Entity.EntityState.Modified;
            oEmpresa.SaveChanges();
        }

        public void EliminarOrganizador (MODELO.Organizador oOrganizador)
        {
            oEmpresa.Organizadores.Remove(oOrganizador);
            oEmpresa.SaveChanges();
        }

        public System.Collections.IEnumerable ObtenerOrganizadores (string nombreOrganizador)
        {
            var organizadores = from organizador in oEmpresa.Organizadores.ToList()
                                where organizador.Nombre.ToLower().Contains(nombreOrganizador.ToLower())
                                select new { ID = organizador.IdOrganizador, Nombre = organizador.Nombre };
            return organizadores.ToList();
        }

        public MODELO.Organizador ObtenerOrganizador (int idOrganizador)
        {
            return oEmpresa.Organizadores.FirstOrDefault(d => d.IdOrganizador == idOrganizador);
        }
    }
}
