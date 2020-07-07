using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTROLADORA
{
    public class cCLIENTES
    {
        private static cCLIENTES instancia;

        public static cCLIENTES obtener_instancia()
        {
            if (instancia == null)
                instancia = new cCLIENTES();
            return instancia;
        }

        DATOS.EmpresaDeSeguros oEmpresa;

        private cCLIENTES()
        {
            oEmpresa = DATOS.EmpresaDeSeguros.obtener_instancia();
        }

        public void AgregarCliente (MODELO.Cliente oCliente)
        {
            oEmpresa.Clientes.Add(oCliente);
            oEmpresa.SaveChanges();
        }

        public void ModificarCliente (MODELO.Cliente oCliente)
        {
            oEmpresa.Entry(oCliente).State = System.Data.Entity.EntityState.Modified;
            oEmpresa.SaveChanges();
        }

        public void EliminarCliente (MODELO.Cliente oCliente)
        {
            oEmpresa.Clientes.Remove(oCliente);
            oEmpresa.SaveChanges();
        }

        public System.Collections.IEnumerable ObtenerClientes (string apellidoCliente, MODELO.Localidad localidad)
        {
            var clientes = from cliente in oEmpresa.Clientes.Include("IdLocalidad").Include("Polizas").ToList()
                           where cliente.Apellido.ToLower().Contains(apellidoCliente.ToLower()) && (localidad.IdLocalidad > 0 ? cliente.IdLocalidad.IdLocalidad == localidad.IdLocalidad : true)
                           select new { ID = cliente.IdCliente, NombreCliente = cliente.Nombre + " " + cliente.Apellido, DNI = cliente.DNI, Edad = cliente.Edad, Dirección = cliente.Direccion, Telefono = cliente.Celular, Polizas = cliente.CalcularPoliza() };
            return clientes.ToList();
        }

        public MODELO.Cliente ObtenerCliente (int idCliente)
        {
            return oEmpresa.Clientes.FirstOrDefault(d => d.IdCliente == idCliente);
        }

        public List<MODELO.Localidad> ObtenerLocalidades (bool todas = false)
        {
            List<MODELO.Localidad> Localidades = oEmpresa.Localidades.ToList();
            if (todas)
            {
                Localidades.Add(new MODELO.Localidad(0, 0, ""));
            }
            return Localidades.ToList();
        }
    }
}
