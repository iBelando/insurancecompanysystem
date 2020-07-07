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
    public partial class frmVehiculos : Form
    {
        private static frmVehiculos instancia;
        public static frmVehiculos obtener_instancia()
        {
            if (instancia == null)
                instancia = new frmVehiculos();
            if (instancia.IsDisposed)
                instancia = new frmVehiculos();
            return instancia;
        }

        CONTROLADORA.cVEHICULOS cVEHICULOS;

        public frmVehiculos()
        {
            InitializeComponent();
            cVEHICULOS = CONTROLADORA.cVEHICULOS.obtener_instancia();
            cmbMarca.DataSource = cVEHICULOS.ObtenerMarcas(true);
            cmbMarca.DisplayMember = "Nombre";
            cmbModelo.DataSource = cVEHICULOS.ObtenerModelos(true);
            cmbModelo.DisplayMember = "Nombre";
            ArmarGrilla();
        }

        public void ArmarGrilla()
        {
            dgvVehiculos.DataSource = null;
            dgvVehiculos.DataSource = cVEHICULOS.ObtenerVehiculos(dtpAño.Value.Year, (MODELO.Marca)cmbMarca.SelectedItem, (MODELO.Modelo)cmbModelo.SelectedItem);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmVehiculo formVehiculo = new frmVehiculo("A", new MODELO.Vehiculo());
            DialogResult dr = formVehiculo.ShowDialog();
            if (dr == DialogResult.OK)
                ArmarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvVehiculos.CurrentRow == null)
            {
                MessageBox.Show("Debe elegir un vehiculo");
                return;
            }
            MODELO.Vehiculo oVehiculo = cVEHICULOS.ObtenerVehiculo(Convert.ToInt32(dgvVehiculos.CurrentRow.Cells[0].Value));
            frmVehiculo formVehiculo = new frmVehiculo("M", oVehiculo);
            DialogResult dr = formVehiculo.ShowDialog();
            if (dr == DialogResult.OK)
                ArmarGrilla();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dgvVehiculos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un vehiculo");
                return;
            }
            MODELO.Vehiculo oVehiculo = cVEHICULOS.ObtenerVehiculo(Convert.ToInt32(dgvVehiculos.CurrentRow.Cells[0].Value));
            frmVehiculo formVehiculo = new frmVehiculo("C", oVehiculo);
            DialogResult dr = formVehiculo.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVehiculos.CurrentRow == null)
            {
                MessageBox.Show("Debes seleccionar un vehículo");
                return;
            }
            MODELO.Vehiculo oVehiculo = cVEHICULOS.ObtenerVehiculo(Convert.ToInt32(dgvVehiculos.CurrentRow.Cells[0].Value));
            if (oVehiculo.Polizas.Count > 0)
            {
                MessageBox.Show("Primero debe eliminar las polizas asociadas al vehiculo");
                return;
            }
            DialogResult dr = MessageBox.Show("¿Confirma que desea eliminar el desarrollador " + oVehiculo.IdMarca.Nombre + " " + oVehiculo.IdModelo.Nombre + " " + oVehiculo.IdVersion.Nombre + " del sistema?", "Eliminar", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                cVEHICULOS.EliminarVehiculo(oVehiculo);
                ArmarGrilla();
            }
        }

        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArmarGrilla();
        }

        private void cmbModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArmarGrilla();
        }

        private void dtpAño_ValueChanged(object sender, EventArgs e)
        {
            ArmarGrilla();
        }
    }
}
