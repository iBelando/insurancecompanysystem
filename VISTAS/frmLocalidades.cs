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
    public partial class frmLocalidades : Form
    {
        private static frmLocalidades instancia;
        public static frmLocalidades obtener_instancia()
        {
            if (instancia == null)
                instancia = new frmLocalidades();
            if (instancia.IsDisposed)
                instancia = new frmLocalidades();
            return instancia;
        }

        CONTROLADORA.cLOCALIDADES cLOCALIDADES;

        public frmLocalidades()
        {
            InitializeComponent();
            cLOCALIDADES = CONTROLADORA.cLOCALIDADES.obtener_instancia();
            ArmarGrilla();
        }

        private void ArmarGrilla()
        {
            dgvLocalidades.DataSource = null;
            dgvLocalidades.DataSource = cLOCALIDADES.ObtenerLocalidades(txtNombre.Text);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmLocalidad formLocalidad = new frmLocalidad("A", new MODELO.Localidad());
            DialogResult dr = formLocalidad.ShowDialog();
            if (dr == DialogResult.OK)
                ArmarGrilla();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvLocalidades.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una localidad");
                return;
            }
            MODELO.Localidad oLocalidad = cLOCALIDADES.ObtenerLocalidad(Convert.ToInt32(dgvLocalidades.CurrentRow.Cells[0].Value));
            frmLocalidad formLocalidad = new frmLocalidad("M", oLocalidad);
            DialogResult dr = formLocalidad.ShowDialog();
            if (dr == DialogResult.OK)
                ArmarGrilla();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dgvLocalidades.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una localidad");
                return;
            }
            MODELO.Localidad oLocalidad = cLOCALIDADES.ObtenerLocalidad(Convert.ToInt32(dgvLocalidades.CurrentRow.Cells[0].Value));
            frmLocalidad formLocalidad = new frmLocalidad("C", oLocalidad);
            DialogResult dr = formLocalidad.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLocalidades.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una localidad");
                return;
            }
            MODELO.Localidad oLocalidad = cLOCALIDADES.ObtenerLocalidad(Convert.ToInt32(dgvLocalidades.CurrentRow.Cells[0].Value));
            if (oLocalidad.Clientes.Count > 0)
            {
                MessageBox.Show("Primero debe eliminar a los clientes que contienen esta localidad");
                return;
            }
            DialogResult dr = MessageBox.Show("¿Confirma que desea eliminar la localidad " + oLocalidad.Nombre + "?", "CONFIRMAR", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                cLOCALIDADES.EliminarLocalidad(oLocalidad);
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
