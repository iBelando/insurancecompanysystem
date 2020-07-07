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
    public partial class frmClientes : Form
    {
        private static frmClientes instancia;
        public static frmClientes obtener_intancia()
        {
            if (instancia == null)
                instancia = new frmClientes();
            if (instancia.IsDisposed)
                instancia = new frmClientes();
            return instancia;
        }

        CONTROLADORA.cCLIENTES cClientes;

        public frmClientes()
        {
            InitializeComponent();
            cClientes = CONTROLADORA.cCLIENTES.obtener_instancia();
            cmbLocalidad.DataSource = cClientes.ObtenerLocalidades(true);
            cmbLocalidad.SelectedIndex = cClientes.ObtenerLocalidades(true).Count - 1;
            ArmarGrilla();
        }

        public void ArmarGrilla()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = cClientes.ObtenerClientes(txtApellido.Text, (MODELO.Localidad)cmbLocalidad.SelectedItem);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCliente formCliente = new frmCliente("A", new MODELO.Cliente());
            DialogResult dr = formCliente.ShowDialog();
            if (dr == DialogResult.OK)
                ArmarGrilla();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Debes seleccionar un cliente");
                return;
            }
            MODELO.Cliente oCliente = cClientes.ObtenerCliente(Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value));
            if (oCliente.Polizas.Count() > 0)
            {
                MessageBox.Show("Elimine las pólizas del cliente");
                return;
            }
            DialogResult dr = MessageBox.Show("¿Confirma que desea eliminar el cliente " + oCliente.Nombre + " " + oCliente.Apellido + " ?", "CONFIRMAR", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                cClientes.EliminarCliente(oCliente);
                ArmarGrilla();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Debes seleccionar un cliente");
                return;
            }
            MODELO.Cliente oCliente = cClientes.ObtenerCliente(Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value));
            frmCliente formCliente = new frmCliente("C", oCliente);
            DialogResult dr = formCliente.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un cliente");
                return;
            }
            MODELO.Cliente oCliente = cClientes.ObtenerCliente(Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value));
            frmCliente formCliente = new frmCliente("M", oCliente);
            DialogResult dr = formCliente.ShowDialog();
            if (dr == DialogResult.OK)
                ArmarGrilla();
        }

        #region BUSCAR
        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            if (txtApellido.TextLength > 3 || txtApellido.TextLength == 0)
                ArmarGrilla();
        }

        private void cmbLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArmarGrilla();
        }
        #endregion
    }
}
