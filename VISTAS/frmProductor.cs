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
    public partial class frmProductor : Form
    {
        string Accion;
        MODELO.Productor oProductor;
        CONTROLADORA.cPRODUCTORES cPRODUCTORES;

        public frmProductor(string miAccion, MODELO.Productor miProductor)
        {
            InitializeComponent();
            cPRODUCTORES = CONTROLADORA.cPRODUCTORES.obtener_instancia();
            Accion = miAccion;
            oProductor = miProductor;
            cmbOrganizador.DataSource = cPRODUCTORES.ObtenerOrganizadores();
            cmbOrganizador.DisplayMember = "Nombre";

            if (Accion != "A")
            {
                txtNombre.Text = oProductor.Nombre;
                txtMatricula.Text = oProductor.Matricula;
                cmbOrganizador.SelectedItem = oProductor.Organizador;

                if (Accion == "C")
                {
                    btnGuardar.Visible = false;
                    btnCancelar.Text = "Cerrar";
                    txtNombre.ReadOnly = Enabled;
                    txtMatricula.ReadOnly = Enabled;
                    cmbOrganizador.Enabled = false;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre válido");
                return;
            }

            if (string.IsNullOrEmpty(txtMatricula.Text))
            {
                MessageBox.Show("Debe ingresar una mátricula válida");
                return;
            }

            oProductor.Nombre = txtNombre.Text;
            oProductor.Matricula = txtMatricula.Text;
            oProductor.Organizador = (MODELO.Organizador)cmbOrganizador.SelectedItem;

            if (Accion == "A")
                cPRODUCTORES.AgregarProductor(oProductor);
            if (Accion == "M")
                cPRODUCTORES.ModificarProductor(oProductor);

            this.DialogResult = DialogResult.OK;
        }
    }
}
