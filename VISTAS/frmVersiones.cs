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
    public partial class frmVersiones : Form
    {
        private static frmVersiones instancia;
        public static frmVersiones obtener_instancia()
        {
            if (instancia == null)
                instancia = new frmVersiones();
            if (instancia.IsDisposed)
                instancia = new frmVersiones();
            return instancia;
        }

        CONTROLADORA.cVERSIONES cVERSIONES;

        public frmVersiones()
        {
            InitializeComponent();
            cVERSIONES = CONTROLADORA.cVERSIONES.obtener_instancia();
            cmbModelo.DataSource = cVERSIONES.ObtenerModelos(true);
            cmbModelo.DisplayMember = "Nombre";
            cmbModelo.SelectedIndex = cVERSIONES.ObtenerModelos(true).Count() - 1;
            ArmarGrilla();
        }

        private void ArmarGrilla()
        {
            dgvVersiones.DataSource = null;
            dgvVersiones.DataSource = cVERSIONES.ObtenerVersiones(txtApellido.Text, (MODELO.Modelo)cmbModelo.SelectedItem);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmVersion formVersion = new frmVersion("A", new MODELO.Version());
            DialogResult dr = formVersion.ShowDialog();
            if (dr == DialogResult.OK)
                ArmarGrilla();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvVersiones.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una versión");
                return;
            }
            MODELO.Version oVersion = cVERSIONES.ObtenerVersion(Convert.ToInt32(dgvVersiones.CurrentRow.Cells[0].Value));
            frmVersion formVersion = new frmVersion("M", oVersion);
            DialogResult dr = formVersion.ShowDialog();
            if (dr == DialogResult.OK)
                ArmarGrilla();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dgvVersiones.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una versión");
                return;
            }
            MODELO.Version oVersion = cVERSIONES.ObtenerVersion(Convert.ToInt32(dgvVersiones.CurrentRow.Cells[0].Value));
            frmVersion formVersion = new frmVersion("C", oVersion);
            DialogResult dr = formVersion.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVersiones.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una versión");
                return;
            }
            MODELO.Version oVersion = cVERSIONES.ObtenerVersion(Convert.ToInt32(dgvVersiones.CurrentRow.Cells[0].Value));
            if (oVersion.Vehiculos.Count > 0)
            {
                MessageBox.Show("Primero debe eliminar los vehículos asociados a la versión");
                return;
            }
            DialogResult dr = MessageBox.Show("¿Confirma que desea eliminar la versión " + oVersion.Nombre + "?", "CONFIRMAR", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                cVERSIONES.EliminarVersion(oVersion);
                ArmarGrilla();
            }
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            if (txtApellido.TextLength > 3 || txtApellido.TextLength == 0)
                ArmarGrilla();
        }

        private void cmbModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArmarGrilla();
        }
    }
}
