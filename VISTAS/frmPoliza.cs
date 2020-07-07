using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VISTAS
{
    public partial class frmPoliza : Form
    {
        string Accion;
        CONTROLADORA.cPOLIZAS cPOLIZAS;
        MODELO.Poliza oPoliza;

        public frmPoliza(string miAccion, MODELO.Poliza miPoliza)
        {
            InitializeComponent();
            cPOLIZAS = CONTROLADORA.cPOLIZAS.obtener_instancia();
            Accion = miAccion;
            oPoliza = miPoliza;
            cmbCliente.DataSource = cPOLIZAS.ObtenerClientes();
            cmbCliente.DisplayMember = "Nombre";
            cmbProductor.DataSource = cPOLIZAS.ObtenerProductores();
            cmbProductor.DisplayMember = "Nombre";
            cmbVehiculo.DataSource = cPOLIZAS.ObtenerVehiculos();
            cmbVehiculo.DisplayMember = "IdVehiculo";
            cmbCobertura.DataSource = cPOLIZAS.ObtenerCoberturas();
            cmbCobertura.DisplayMember = "Nombre";

            if (Accion != "A")
            {
                txtNumero.Text = oPoliza.Numero.ToString();
                cmbProductor.SelectedItem = oPoliza.IdProductor;
                cmbCliente.SelectedItem = oPoliza.IdCliente;
                cmbVehiculo.SelectedItem = oPoliza.IdVehiculo;
                cmbCobertura.SelectedItem = oPoliza.IdCobertura;
                dtpVigenciaDesde.Value = oPoliza.VigenciaDesde;
                dtpVigenciaHasta.Value = oPoliza.VigenciaHasta;
                txtPatente.Text = oPoliza.Patente;

                if (Accion == "C")
                {
                    btnGuardar.Visible = false;
                    btnCancelar.Text = "Cerrar";
                    txtNumero.ReadOnly = Enabled;
                    cmbProductor.Enabled = false;
                    cmbCliente.Enabled = false;
                    cmbVehiculo.Enabled = false;
                    cmbCobertura.Enabled = false;
                    dtpVigenciaDesde.Enabled = false;
                    dtpVigenciaHasta.Enabled = false;
                    txtPatente.ReadOnly = Enabled;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int numero;
            if (!int.TryParse(txtNumero.Text, out numero))
            {
                MessageBox.Show("Debe completar con un número válido");
                return;
            }
            if(dtpVigenciaDesde.Value > DateTime.Now)
            {

                MessageBox.Show("Debes completar con la vigencia desde correspondiente");
                return;
            }
            if (dtpVigenciaHasta.Value < DateTime.Now)
            {
                MessageBox.Show("Debes completar con la vigencia hasta correspondiente");
                return;
            }
            if (string.IsNullOrEmpty(txtPatente.Text))
            {
                MessageBox.Show("Debes completar con una patente valida");
                return;
            }

            oPoliza.IdCobertura = (MODELO.Cobertura)cmbCobertura.SelectedItem;
            oPoliza.Numero = numero;
            oPoliza.Patente = txtPatente.Text;
            oPoliza.IdCliente = (MODELO.Cliente)cmbCliente.SelectedItem;
            oPoliza.IdProductor = (MODELO.Productor)cmbProductor.SelectedItem;
            oPoliza.IdVehiculo = (MODELO.Vehiculo)cmbVehiculo.SelectedItem;
            oPoliza.VigenciaDesde = dtpVigenciaDesde.Value;
            oPoliza.VigenciaHasta = dtpVigenciaHasta.Value;

            if (Accion == "A")
            {
                cPOLIZAS.CrearCuotas(oPoliza);
                cPOLIZAS.AgregarPoliza(oPoliza);
            }
            if (Accion == "M")
                cPOLIZAS.ModificarPoliza(oPoliza);

            this.DialogResult = DialogResult.OK;
        }
    }
}
