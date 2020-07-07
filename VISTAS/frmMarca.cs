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
    public partial class frmMarca : Form
    {
        string Accion;
        MODELO.Marca oMarca;
        CONTROLADORA.cMARCAS cMarcas;
        public frmMarca(string miAccion, MODELO.Marca miMarca)
        {
            InitializeComponent();
            Accion = miAccion;
            oMarca = miMarca;
            cMarcas = CONTROLADORA.cMARCAS.obtener_instancia();

            if (Accion != "A")
            {
                txtNombre.Text = oMarca.Nombre;

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
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debes agregar un nombre válido");
                return;
            }

            oMarca.Nombre = txtNombre.Text;

            if (Accion == "A")
                cMarcas.AgregarMarca(oMarca);
            if (Accion == "M")
                cMarcas.ModificarMarca(oMarca);

            this.DialogResult = DialogResult.OK;
        }
    }
}
