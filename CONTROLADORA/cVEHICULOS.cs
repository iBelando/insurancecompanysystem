using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTROLADORA
{
    public class cVEHICULOS
    {
        private static cVEHICULOS instancia;

        public static cVEHICULOS obtener_instancia()
        {
            if (instancia == null)
                instancia = new cVEHICULOS();
            return instancia;
        }

        DATOS.EmpresaDeSeguros oEmpresa;

        private cVEHICULOS()
        {
            oEmpresa = DATOS.EmpresaDeSeguros.obtener_instancia();
        }

        public void AgregarVehiculo(MODELO.Vehiculo oVehiculo)
        {
            oEmpresa.Vehiculos.Add(oVehiculo);
            oEmpresa.SaveChanges();
        }

        public void ModificarVehiculo(MODELO.Vehiculo oVehiculo)
        {
            oEmpresa.Entry(oVehiculo).State = System.Data.Entity.EntityState.Modified;
            oEmpresa.SaveChanges();
        }

        public void EliminarVehiculo(MODELO.Vehiculo oVehiculo)
        {
            oEmpresa.Vehiculos.Remove(oVehiculo);
            oEmpresa.SaveChanges();
        }

        public MODELO.Vehiculo ObtenerVehiculo(int idVehiculo)
        {
            return oEmpresa.Vehiculos.FirstOrDefault(i => i.IdVehiculo == idVehiculo);
        }

        public System.Collections.IEnumerable ObtenerVehiculos(int Año, MODELO.Marca Marca, MODELO.Modelo Modelo)
        {
            var vehiculos = from vehiculo in oEmpresa.Vehiculos.Include("Año").Include("IdMarca").Include("IdModelo").Include("IdVersion").Include("Polizas").ToList()
                            where vehiculo.Año.Year <= Año && Marca.IdMarca > 0 ? vehiculo.IdMarca.IdMarca == Marca.IdMarca : true && Modelo.IdModelo > 0 ? vehiculo.IdModelo.IdModelo == Modelo.IdModelo : true
                            select new { ID = vehiculo.IdModelo, Año = vehiculo.Año.Year, Marca = vehiculo.IdMarca.Nombre, Modelo = vehiculo.IdModelo.Nombre, Version = vehiculo.IdVersion.Nombre, Polizas = vehiculo.Polizas.Count() };
            return vehiculos.ToList();
        }

         public List<MODELO.Marca> ObtenerMarcas(bool todos = false)
        {
            List<MODELO.Marca> Marcas = oEmpresa.Marcas.ToList();
            if (todos)
                Marcas.Add(new MODELO.Marca(0, ""));
            return Marcas.ToList();
        }

        public List<MODELO.Modelo> ObtenerModelos(bool todos = false)
        {
            List<MODELO.Modelo> Modelos = oEmpresa.Modelos.ToList();
            if (todos)
                Modelos.Add(new MODELO.Modelo(0, ""));
            return Modelos.ToList();
        }

        public List<MODELO.Version> ObtenerVersiones()
        {
            List<MODELO.Version> Versiones = oEmpresa.Versiones.ToList();
            return Versiones.ToList();
        }
    }
}
