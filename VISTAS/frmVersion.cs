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
    public partial class frmVersion : Form
    {
        string Accion;
        MODELO.Version oVersion;
        CONTROLADORA.cVERSIONES cVERSIONES;

        public frmVersion(string miAccion, MODELO.Version miVersion)
        {
            InitializeComponent();
            cVERSIONES = CONTROLADORA.cVERSIONES.obtener_instancia();
            Accion = miAccion;
            oVersion = miVersion;
            cmbModelo.DataSource = cVERSIONES.ObtenerModelos();
            cmbModelo.DisplayMember = "Nombre";

            if (Accion != "A")
            {
                txtNombre.Text = oVersion.Nombre;

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
                MessageBox.Show("Debe completar con un nombre válido");
                return;
            }

            oVersion.Nombre = txtNombre.Text;
            MODELO.Modelo oModelo = (MODELO.Modelo)cmbModelo.SelectedItem;
            oVersion.Modelos.Add(oModelo);

            if (Accion == "A")
                cVERSIONES.AgregarVersion(oVersion);
            if (Accion == "M")
                cVERSIONES.ModificarVersion(oVersion);

            this.DialogResult = DialogResult.OK;
        }
    }
}
