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
    public partial class frmOrganizadores : Form
    {
        private static frmOrganizadores instancia;
        public static frmOrganizadores obtenerInstancia()
        {
            if (instancia == null)
                instancia = new frmOrganizadores();
            if (instancia.IsDisposed)
                instancia = new frmOrganizadores();
            return instancia;
        }

        CONTROLADORA.cORGANIZADORES cORGANIZADORES;
        public frmOrganizadores()
        {
            InitializeComponent();
            cORGANIZADORES = CONTROLADORA.cORGANIZADORES.obtener_instancia();

            ArmarGrilla();
        }

        private void ArmarGrilla()
        {
            dgvOrganizadores.DataSource = null;
            dgvOrganizadores.DataSource = cORGANIZADORES.ObtenerOrganizadores(txtNombre.Text);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmOrganizador formOrganizador = new frmOrganizador("A", new MODELO.Organizador());
            DialogResult dr = formOrganizador.ShowDialog();
            if (dr == DialogResult.OK)
                ArmarGrilla();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvOrganizadores.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un organizador");
                return;
            }
            MODELO.Organizador oOrganizador = cORGANIZADORES.ObtenerOrganizador(Convert.ToInt32(dgvOrganizadores.CurrentRow.Cells[0].Value));
            frmOrganizador formOrganizador = new frmOrganizador("M", oOrganizador);
            DialogResult dr = formOrganizador.ShowDialog();
            if (dr == DialogResult.OK)
                ArmarGrilla();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dgvOrganizadores.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un organizador");
                return;
            }
            MODELO.Organizador oOrganizador = cORGANIZADORES.ObtenerOrganizador(Convert.ToInt32(dgvOrganizadores.CurrentRow.Cells[0].Value));
            frmOrganizador formOrganizador = new frmOrganizador("C", oOrganizador);
            DialogResult dr = formOrganizador.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvOrganizadores.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un organizador");
                return;
            }
            MODELO.Organizador oOrganizador = cORGANIZADORES.ObtenerOrganizador(Convert.ToInt32(dgvOrganizadores.CurrentRow.Cells[0].Value));
            if (oOrganizador.Productores.Count > 0)
            {
                MessageBox.Show("Primero debe eliminar a los productores relacionados a este organizador");
                return;
            }
            DialogResult dr = MessageBox.Show("¿Confirma que desea eliminar el organizador " + oOrganizador.Nombre + "?", "CONFIRMAR", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                cORGANIZADORES.EliminarOrganizador(oOrganizador);
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
