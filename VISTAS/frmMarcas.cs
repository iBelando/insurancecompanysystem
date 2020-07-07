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
    public partial class frmMarcas : Form
    {
        private static frmMarcas instancia;
        public static frmMarcas obtener_instancia()
        {
            if (instancia == null)
                instancia = new frmMarcas();
            if (instancia.IsDisposed)
                instancia = new frmMarcas();
            return instancia;
        }

        CONTROLADORA.cMARCAS cMARCAS;

        public frmMarcas()
        {
            InitializeComponent();
            cMARCAS = CONTROLADORA.cMARCAS.obtener_instancia();
            ArmarGrilla();
        }

        public void ArmarGrilla()
        {
            dgvMarcas.DataSource = null;
            dgvMarcas.DataSource = cMARCAS.ObtenerMarcas(txtNombre.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmMarca formMarca = new frmMarca("A", new MODELO.Marca());
            DialogResult dr = formMarca.ShowDialog();
            if (dr == DialogResult.OK)
                ArmarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una marca");
                return;
            }
            MODELO.Marca oMarca = cMARCAS.ObtenerMarca(Convert.ToInt32(dgvMarcas.CurrentRow.Cells[0].Value));
            frmMarca formMarca = new frmMarca("M", oMarca);
            DialogResult dr = formMarca.ShowDialog();
            if (dr == DialogResult.OK)
                ArmarGrilla();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una marca");
                return;
            }
            MODELO.Marca oMarca = cMARCAS.ObtenerMarca(Convert.ToInt32(dgvMarcas.CurrentRow.Cells[0].Value));
            frmMarca formMarca = new frmMarca("C", oMarca);
            DialogResult dr = formMarca.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una marca");
                return;
            }
            MODELO.Marca oMarca = cMARCAS.ObtenerMarca(Convert.ToInt32(dgvMarcas.CurrentRow.Cells[0].Value));
            if (oMarca.Vehiculos.Count > 0)
            {
                MessageBox.Show("Primero debes eliminar los vehiculos que estean relacionados con la marca");
                return;
            }
            DialogResult dr = MessageBox.Show("¿Confirma que desea eliminar la marca " + oMarca.Nombre + "?", "CONFIRMAR", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                cMARCAS.EliminarMarca(oMarca);
                ArmarGrilla();
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.TextLength > 3 || txtNombre.TextLength == 0)
                ArmarGrilla();
        }
    }
}
