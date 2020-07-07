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
    public partial class frmVehiculo : Form
    {
        string Accion;
        MODELO.Vehiculo oVehiculo;
        CONTROLADORA.cVEHICULOS cVEHICULOS;

        public frmVehiculo(string miAccion, MODELO.Vehiculo Vehiculo)
        {
            InitializeComponent();
            cVEHICULOS = CONTROLADORA.cVEHICULOS.obtener_instancia();
            oVehiculo = Vehiculo;
            Accion = miAccion;
            cmbMarca.DataSource = cVEHICULOS.ObtenerMarcas();
            cmbMarca.DisplayMember = "Nombre";
            cmbModelo.DataSource = cVEHICULOS.ObtenerModelos();
            cmbModelo.DisplayMember = "Nombre";
            cmbVersion.DataSource = cVEHICULOS.ObtenerVersiones();
            cmbVersion.DisplayMember = "Nombre";

            if (Accion != "A")
            {
                cmbMarca.SelectedItem = oVehiculo.IdMarca;
                cmbModelo.SelectedItem = oVehiculo.IdModelo;
                cmbVersion.SelectedItem = oVehiculo.IdVersion;
                dtpAño.Value = oVehiculo.Año;

                if (Accion == "C")
                {
                    btnGuardar.Visible = false;
                    btnCancelar.Text = "Cerrar";
                    cmbMarca.Enabled = false;
                    cmbModelo.Enabled = false;
                    cmbVersion.Enabled = false;
                    dtpAño.Enabled = false;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dtpAño.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha es incorrecta. Debe ingresar una fecha menor a la correspondiente");
                return;
            }

            oVehiculo.Año = dtpAño.Value;
            oVehiculo.IdMarca = (MODELO.Marca)cmbMarca.SelectedItem;
            oVehiculo.IdModelo = (MODELO.Modelo)cmbModelo.SelectedItem;
            oVehiculo.IdVersion = (MODELO.Version)cmbVersion.SelectedItem;

            if (Accion == "A")
                cVEHICULOS.AgregarVehiculo(oVehiculo);
            if (Accion == "M")
                cVEHICULOS.ModificarVehiculo(oVehiculo);

            this.DialogResult = DialogResult.OK;
        }
    }
}
