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
    public partial class frmPolizas : Form
    {
        private static frmPolizas instancia;
        public static frmPolizas obtener_instancia()
        {
            if (instancia == null)
                instancia = new frmPolizas();
            if (instancia.IsDisposed)
                instancia = new frmPolizas();
            return instancia;
        }
        int miNumero;
        CONTROLADORA.cPOLIZAS cPOLIZAS;

        public frmPolizas()
        {
            InitializeComponent();
            cPOLIZAS = CONTROLADORA.cPOLIZAS.obtener_instancia();
            cmbCliente.DataSource = cPOLIZAS.ObtenerClientes(true);
            cmbCliente.DisplayMember = "Nombre";
            cmbProductor.DataSource = cPOLIZAS.ObtenerProductores(true);
            cmbProductor.DisplayMember = "Nombre";
            cmbOrganizador.DataSource = cPOLIZAS.ObtenerOrganizadores(true);
            cmbOrganizador.DisplayMember = "Nombre";
            ArmarGrilla();
        }

        public void ArmarGrilla()
        {
            dgvPolizas.DataSource = null;
            dgvPolizas.DataSource = cPOLIZAS.ObtenerPolizas((MODELO.Productor)cmbProductor.SelectedItem, (MODELO.Organizador)cmbOrganizador.SelectedItem, (MODELO.Cliente)cmbCliente.SelectedItem, miNumero, txtPatente.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmPoliza frmPoliza = new frmPoliza("A", new MODELO.Poliza());
            if (frmPoliza.ShowDialog() == DialogResult.OK)
                ArmarGrilla();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dgvPolizas.CurrentRow == null)
            {
                MessageBox.Show("Debes elegir una poliza");
                return;
            }
            MODELO.Poliza poliza = cPOLIZAS.ObtenerPoliza(Convert.ToInt32(dgvPolizas.CurrentRow.Cells[0].Value));
            frmPoliza frmPoliza = new frmPoliza("C", poliza);
            frmPoliza.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvPolizas.CurrentRow == null)
            {
                MessageBox.Show("Debes elegir una poliza");
                return;
            }
            MODELO.Poliza poliza = cPOLIZAS.ObtenerPoliza(Convert.ToInt32(dgvPolizas.CurrentRow.Cells[0].Value));
            frmPoliza frmPoliza = new frmPoliza("M", poliza);
            if (frmPoliza.ShowDialog() == DialogResult.OK)
                ArmarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPolizas.CurrentRow == null)
            {
                MessageBox.Show("Debes elegir una poliza");
                return;
            }
            MODELO.Poliza poliza = cPOLIZAS.ObtenerPoliza(Convert.ToInt32(dgvPolizas.CurrentRow.Cells[0].Value));
            DialogResult dr = MessageBox.Show("Seguro que desea eliminar la poliza: " + poliza.Numero + " del sistema?", "Eliminar", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                cPOLIZAS.EliminarPoliza(poliza);
                ArmarGrilla();
            }
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNumero.Text, out miNumero))
            {
                MessageBox.Show("Debe escribir un numero de poliza valido");
                if (txtNumero.TextLength == 0)
                {
                    ArmarGrilla();
                }
                return;
            }
        }

        private void txtPatente_TextChanged(object sender, EventArgs e)
        {
            if (txtNumero.Text == "")
                ArmarGrilla();
        }

        private void cmbOrganizador_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArmarGrilla();
        }

        private void cmbProductor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArmarGrilla();
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArmarGrilla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvPolizas.CurrentRow == null)
            {
                MessageBox.Show("Debes elegir una poliza");
                return;
            }
            MODELO.Poliza poliza = cPOLIZAS.ObtenerPoliza(Convert.ToInt32(dgvPolizas.CurrentRow.Cells[0].Value));
            frmCuotas frmCuotas = new frmCuotas(poliza);
            if (frmCuotas.ShowDialog() == DialogResult.OK)
                ArmarGrilla();
        }
    }
}
