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
    public partial class frmModelos : Form
    {
        private static frmModelos instancia;
        public static frmModelos obtener_instancia()
        {
            if (instancia == null)
                instancia = new frmModelos();
            if (instancia.IsDisposed)
                instancia = new frmModelos();
            return instancia;
        }

        CONTROLADORA.cMODELOS cMODELOS;

        public frmModelos()
        {
            InitializeComponent();
            cMODELOS = CONTROLADORA.cMODELOS.obtener_instancia();
            cmbMarca.DataSource = cMODELOS.ObtenerMarcas(true);
            cmbMarca.DisplayMember = "Nombre";
            cmbMarca.SelectedIndex = cMODELOS.ObtenerMarcas(true).Count() - 1;
            ArmarGrilla();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ArmarGrilla()
        {
            dgvModelos.DataSource = null;
            dgvModelos.DataSource = cMODELOS.ObtenerModelos(txtNombre.Text, (MODELO.Marca)cmbMarca.SelectedItem);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmModelo formModelo = new frmModelo("A", new MODELO.Modelo());
            DialogResult dr = formModelo.ShowDialog();
            if (dr == DialogResult.OK)
                ArmarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvModelos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un modelo");
                return;
            }
            MODELO.Modelo oModelo = cMODELOS.ObtenerModelo(Convert.ToInt32(dgvModelos.CurrentRow.Cells[0].Value));
            frmModelo formModelo = new frmModelo("M", oModelo);
            DialogResult dr = formModelo.ShowDialog();
            if (dr == DialogResult.OK)
                ArmarGrilla();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if(dgvModelos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un modelo");
                return;
            }
            MODELO.Modelo oModelo = cMODELOS.ObtenerModelo(Convert.ToInt32(dgvModelos.CurrentRow.Cells[0].Value));
            frmModelo formModelo = new frmModelo("C", oModelo);
            DialogResult dr = formModelo.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvModelos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un modelo");
                return;
            }
            MODELO.Modelo oModelo = cMODELOS.ObtenerModelo(Convert.ToInt32(dgvModelos.CurrentRow.Cells[0].Value));
            if (oModelo.Vehiculos.Count > 0)
            {
                MessageBox.Show("Elimine los vehiculos que están asociados al modelo");
                return;
            }
            DialogResult dr = MessageBox.Show("¿Confirma que desea eliminar el modelo " + oModelo.Nombre + "?", "CONFIRMAR", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                cMODELOS.EliminarModelo(oModelo);
                ArmarGrilla();
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.TextLength > 3 || txtNombre.TextLength == 0)
                ArmarGrilla();
        }

        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArmarGrilla();
        }
    }
}
