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
    public partial class frmOrganizador : Form
    {
        string Accion;
        CONTROLADORA.cORGANIZADORES cORGANIZADORES;
        MODELO.Organizador oOrganizador;

        public frmOrganizador(string miAccion, MODELO.Organizador miOrganizador)
        {
            InitializeComponent();

            cORGANIZADORES = CONTROLADORA.cORGANIZADORES.obtener_instancia();
            oOrganizador = miOrganizador;
            Accion = miAccion;

            if (Accion != "A")
            {
                txtNombre.Text = oOrganizador.Nombre;

                if (Accion == "C")
                {
                    btnGuardar.Visible = false;
                    btnCancelar.Text = "Cerrar";
                    txtNombre.ReadOnly = Enabled;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe Agregar un nombre válido");
                return;
            }

            oOrganizador.Nombre = txtNombre.Text;

            if (Accion == "A")
                cORGANIZADORES.AgregarOrganizador(oOrganizador);
            if (Accion == "M")
                cORGANIZADORES.ModificarOrganizador(oOrganizador);

            this.DialogResult = DialogResult.OK;
        }
    }
}
