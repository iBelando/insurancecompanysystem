using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CONTROLADORA
{
    public class cPOLIZAS
    {
        private static cPOLIZAS instancia;

        public static cPOLIZAS obtener_instancia()
        {
            if (instancia == null)
                instancia = new cPOLIZAS();
            return instancia;
        }

        DATOS.EmpresaDeSeguros oEmpresa;

        public cPOLIZAS()
        {
            oEmpresa = DATOS.EmpresaDeSeguros.obtener_instancia();
        }

        public void AgregarPoliza(MODELO.Poliza oPoliza)
        {
            oEmpresa.Polizas.Add(oPoliza);
            oEmpresa.SaveChanges();
        }

        public void ModificarPoliza(MODELO.Poliza oPoliza)
        {
            oEmpresa.Entry(oPoliza).State = System.Data.Entity.EntityState.Modified;
            oEmpresa.SaveChanges();
        }

        public void EliminarPoliza(MODELO.Poliza oPoliza)
        {
            oEmpresa.Polizas.Remove(oPoliza);
            oEmpresa.SaveChanges();
        }

        public System.Collections.IEnumerable ObtenerPolizas(MODELO.Productor productor, MODELO.Organizador organizador, MODELO.Cliente persona, int numero, string patente)
        {
            var polizas = from poliza in oEmpresa.Polizas.Include(_ => _.IdProductor.Organizador).Include("Persona").Include(_ => _.IdVehiculo.IdModelo).Include("Cobertura").Include("Cuotas").ToList()
                          where poliza.Numero.ToString().Contains(numero.ToString()) && poliza.Patente.ToLower().Contains(patente.ToLower()) && productor.IdProductor > 0 ? poliza.IdProductor.IdProductor == productor.IdProductor : true && organizador.IdOrganizador > 0 ? poliza.IdProductor.Organizador.IdOrganizador == organizador.IdOrganizador : true && persona.IdCliente > 0 ? poliza.IdCliente.IdCliente == persona.IdCliente : true
                          select new { ID = poliza.IdPoliza, Numero = poliza.Numero, Cliente = poliza.IdCliente.Nombre + " " + poliza.IdCliente.Apellido, Productor = poliza.IdProductor.Nombre, Vehiculo = poliza.IdVehiculo.IdModelo.Nombre, Cobertura = poliza.IdCobertura.Nombre, Estado = poliza.Estado(), Patente = poliza.Patente, ImporteTotal = poliza.ImporteTotal()};
            return polizas.ToList();
        }

        public MODELO.Poliza ObtenerPoliza (int numeroPoliza)
        {
            return oEmpresa.Polizas.FirstOrDefault(d => d.Numero == numeroPoliza);
        }

        public List<MODELO.Productor> ObtenerProductores(bool todos = false)
        {
            List<MODELO.Productor> productores = oEmpresa.Productores.ToList();
            if (todos)
                productores.Add(new MODELO.Productor(0, ""));
            return productores.ToList(); ;
        }

        public List<MODELO.Organizador> ObtenerOrganizadores(bool todos = false)
        {
            List<MODELO.Organizador> organizadores = oEmpresa.Organizadores.ToList();
            if (todos)
                organizadores.Add(new MODELO.Organizador(0, ""));
            return organizadores.ToList(); ;
        }

        public List<MODELO.Cliente> ObtenerClientes(bool todos = false)
        {
            List<MODELO.Cliente> personas = oEmpresa.Clientes.ToList();
            if (todos)
                personas.Add(new MODELO.Cliente(0, ""));
            return personas.ToList();
        }

        public void CrearCuotas(MODELO.Poliza poliza)
        {
            MODELO.Cuota oCuota;
            for (int i = 0; i < poliza.IdCobertura.NroCuotas - 1; i++)
            {
                oCuota = new MODELO.Cuota();
                oCuota.NroCuota = i;
                oCuota.Importe = poliza.IdCobertura.ImporteCuota;
                oCuota.Estado = "Pendiente";
                poliza.Cuotas.Add(oCuota);
                oCuota = null;
            }
        }

        public List<MODELO.Cuota> ObtenerCuotas(MODELO.Poliza poliza)
        {
            List<MODELO.Cuota> cuotas = poliza.Cuotas.ToList();
            return cuotas.ToList();
        }

        public List<MODELO.Cobertura> ObtenerCoberturas()
        {
            List<MODELO.Cobertura> coberturas = oEmpresa.Coberturas.ToList();
            return coberturas.ToList();
        }

        public List<MODELO.Vehiculo> ObtenerVehiculos()
        {
            List<MODELO.Vehiculo> vehiculos = oEmpresa.Vehiculos.ToList();
            return vehiculos.ToList();
        }

    }
}
