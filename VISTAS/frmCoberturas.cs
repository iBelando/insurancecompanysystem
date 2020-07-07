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
    public partial class frmCoberturas : Form
    {
        private static frmCoberturas instancia;
        public static frmCoberturas obtener_instancia()
        {
            if (instancia == null)
                instancia = new frmCoberturas();
            if (instancia.IsDisposed)
                instancia = new frmCoberturas();
            return instancia;
        }

        CONTROLADORA.cCOBERTURAS cCOBERTURAS;

        public frmCoberturas()
        {
            InitializeComponent();
            cCOBERTURAS = CONTROLADORA.cCOBERTURAS.obtener_instancia();
            ArmarGrilla();
        }

        public void ArmarGrilla()
        {
            dgvCoberturas.DataSource = null;
            dgvCoberturas.DataSource = cCOBERTURAS.ObtenerCoberturas(txtNombre.Text);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCobertura formCobertura = new frmCobertura("A", new MODELO.Cobertura());
            DialogResult dr = formCobertura.ShowDialog();
            if (dr == DialogResult.OK)
                ArmarGrilla();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvCoberturas.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una cobertura");
                return;
            }
            MODELO.Cobertura oCobertura = cCOBERTURAS.ObtenerCobertura(Convert.ToInt32(dgvCoberturas.CurrentRow.Cells[0].Value));
            frmCobertura formCobertura = new frmCobertura("M", oCobertura);
            DialogResult dr = formCobertura.ShowDialog();
            if (dr == DialogResult.OK)
                ArmarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCoberturas.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una coberturar");
                return;
            }
            MODELO.Cobertura oCobertura = cCOBERTURAS.ObtenerCobertura(Convert.ToInt32(dgvCoberturas.CurrentRow.Cells[0].Value));
            if (oCobertura.Polizas.Count > 0)
            {
                MessageBox.Show("Primero debe eliminar las polizas asociadas a la cobertura");
                return;
            }
            DialogResult dr = MessageBox.Show("¿Confirma que desea eliminar la cobertura " + oCobertura.Nombre + "?", "CONFIRMAR", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                cCOBERTURAS.EliminarCobertura(oCobertura);
                ArmarGrilla();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dgvCoberturas.CurrentRow == null)
            {
                MessageBox.Show("Debes seleccionar un desarrollador");
                return;
            }
            MODELO.Cobertura oCobertura = cCOBERTURAS.ObtenerCobertura(Convert.ToInt32(dgvCoberturas.CurrentRow.Cells[0].Value));
            frmCobertura formCobertura = new frmCobertura("C", oCobertura);
            DialogResult dr = formCobertura.ShowDialog();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.TextLength > 3 || txtNombre.TextLength == 0)
                ArmarGrilla();
        }
    }
}
