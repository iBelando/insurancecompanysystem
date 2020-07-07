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
    public partial class frmProductores : Form
    {
        private static frmProductores instancia;
        public static frmProductores obtener_instancia()
        {
            if (instancia == null)
                instancia = new frmProductores();
            if (instancia.IsDisposed)
                instancia = new frmProductores();
            return instancia;
        }

        CONTROLADORA.cPRODUCTORES cPRODUCTORES;

        public frmProductores()
        {
            InitializeComponent();
            cPRODUCTORES = CONTROLADORA.cPRODUCTORES.obtener_instancia();
            cmbOrganizador.DataSource = cPRODUCTORES.ObtenerOrganizadores(true);
            cmbOrganizador.DisplayMember = "Nombre";
            cmbOrganizador.SelectedIndex = cPRODUCTORES.ObtenerOrganizadores(true).Count() - 1;
            ArmarGrilla();
        }

        public void ArmarGrilla()
        {
            dgvProductores.DataSource = null;
            dgvProductores.DataSource = cPRODUCTORES.ObtenerProductores(txtApellido.Text, (MODELO.Organizador)cmbOrganizador.SelectedItem);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmProductor formProductor = new frmProductor("A", new MODELO.Productor());
            DialogResult dr = formProductor.ShowDialog();
            if (dr == DialogResult.OK)
                ArmarGrilla();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProductores.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un productor");
                return;
            }
            MODELO.Productor oProductor = cPRODUCTORES.ObtenerProductor(Convert.ToInt32(dgvProductores.CurrentRow.Cells[0].Value));
            frmProductor formProductor = new frmProductor("M", oProductor);
            DialogResult dr = formProductor.ShowDialog();
            if (dr == DialogResult.OK)
                ArmarGrilla();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dgvProductores.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un productor");
                return;
            }
            MODELO.Productor oProductor = cPRODUCTORES.ObtenerProductor(Convert.ToInt32(dgvProductores.CurrentRow.Cells[0].Value));
            frmProductor formProductor = new frmProductor("C", oProductor);
            DialogResult dr = formProductor.ShowDialog();
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            if (txtApellido.TextLength > 3 || txtApellido.TextLength == 0)
                ArmarGrilla();
        }

        private void cmbOrganizador_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArmarGrilla();
        }
    }
}
