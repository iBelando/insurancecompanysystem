using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTROLADORA
{
    public class cPRODUCTORES
    {
        private static cPRODUCTORES instancia;

        public static cPRODUCTORES obtener_instancia()
        {
            if (instancia == null)
                instancia = new cPRODUCTORES();
            return instancia;
        }

        DATOS.EmpresaDeSeguros oEmpresa;

        private cPRODUCTORES()
        {
            oEmpresa = DATOS.EmpresaDeSeguros.obtener_instancia();
        }

        public void AgregarProductor (MODELO.Productor oProductor)
        {
            oEmpresa.Productores.Add(oProductor);
            oEmpresa.SaveChanges();
        }

        public void ModificarProductor (MODELO.Productor oProductor)
        {
            oEmpresa.Entry(oProductor).State = System.Data.Entity.EntityState.Modified;
            oEmpresa.SaveChanges();
        }

        public void EliminarProductor (MODELO.Productor oProductor)
        {
            oEmpresa.Productores.Remove(oProductor);
            oEmpresa.SaveChanges();
        }

        public System.Collections.IEnumerable ObtenerProductores (string nombreProductor, MODELO.Organizador Organizador)
        {
            var productores = from productor in oEmpresa.Productores.Include("Organizador").Include("Polizas").ToList()
                              where productor.Nombre.ToLower().Contains(nombreProductor.ToLower()) && (Organizador.IdOrganizador > 0 ? productor.Organizador.IdOrganizador == Organizador.IdOrganizador : true)
                              select new { ID = productor.IdProductor, Nombre = productor.Nombre, Matricula = productor.Matricula, Organizador = productor.Organizador.Nombre, PolizasVendidas = productor.Polizas.Count };
            return productores.ToList();
        }

        public MODELO.Productor ObtenerProductor (int idProductor)
        {
            return oEmpresa.Productores.FirstOrDefault(d => d.IdProductor == idProductor);
        }

        public List<MODELO.Organizador> ObtenerOrganizadores (bool todos = false)
        {
            List<MODELO.Organizador> Organizadores = oEmpresa.Organizadores.ToList();
            if (todos)
            {
                Organizadores.Add(new MODELO.Organizador(0, ""));
            }
            return Organizadores.ToList();
        }
    }
}
