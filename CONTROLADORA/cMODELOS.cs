using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTROLADORA
{
    public class cMODELOS
    {
        private static cMODELOS instancia;

        public static cMODELOS obtener_instancia()
        {
            if (instancia == null)
                instancia = new cMODELOS();
            return instancia;
        }

        DATOS.EmpresaDeSeguros oEmpresa;

        public cMODELOS()
        {
            oEmpresa = DATOS.EmpresaDeSeguros.obtener_instancia();
        }

        public void AgregarModelo(MODELO.Modelo oModelo)
        {
            oEmpresa.Modelos.Add(oModelo);
            oEmpresa.SaveChanges();
        }

        public void ModificarModelo(MODELO.Modelo oModelo)
        {
            oEmpresa.Entry(oEmpresa).State = System.Data.Entity.EntityState.Modified;
            oEmpresa.SaveChanges();
        }

        public void EliminarModelo(MODELO.Modelo oModelo)
        {
            oEmpresa.Modelos.Remove(oModelo);
            oEmpresa.SaveChanges();
        }

        public System.Collections.IEnumerable ObtenerModelos(string nombreModelo, MODELO.Marca Marca)
        {
            var modelos = from modelo in oEmpresa.Modelos.Include("Marca").Include("Vehiculos").Include("Versiones").ToList()
                          where modelo.Nombre.ToLower().Contains(nombreModelo.ToLower()) && Marca.IdMarca > 0 ? modelo.IdMarca == Marca.IdMarca : true
                          select new { ID = modelo.IdModelo, Nombre = modelo.Nombre, Marca = modelo.Marca.Nombre, Vehiculos = modelo.Vehiculos.Count() };
            return modelos.ToList();
        }

        public MODELO.Modelo ObtenerModelo(int idModelo)
        {
            return oEmpresa.Modelos.FirstOrDefault(d => d.IdModelo == idModelo);
        }

        public List<MODELO.Marca> ObtenerMarcas(bool todos = false)
        {
            List<MODELO.Marca> Marcas = oEmpresa.Marcas.ToList();
            if (todos)
                Marcas.Add(new MODELO.Marca(0, ""));
            return Marcas.ToList();
        }

        public List<MODELO.Version> ObtenerVersiones()
        {
            List<MODELO.Version> Versiones = oEmpresa.Versiones.ToList();
            return Versiones.ToList();
        }
    }
}
