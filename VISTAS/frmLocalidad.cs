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
    public partial class frmLocalidad : Form
    {
        string Accion;
        MODELO.Localidad oLocalidad;
        CONTROLADORA.cLOCALIDADES cLOCALIDADES;

        public frmLocalidad(string miAccion, MODELO.Localidad miLocalidad)
        {
            InitializeComponent();
            cLOCALIDADES = CONTROLADORA.cLOCALIDADES.obtener_instancia();
            Accion = miAccion;
            oLocalidad = miLocalidad;

            if (Accion != "A")
            {
                txtNombre.Text = oLocalidad.Nombre;
                txtCodigoPostal.Text = oLocalidad.CodPostal.ToString();
                if (Accion == "C")
                {
                    btnGuardar.Visible = false;
                    btnCancelar.Text = "Cerrar";
                    txtNombre.ReadOnly = Enabled;
                    txtCodigoPostal.ReadOnly = Enabled;
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

            int codigoPostal;
            if (!int.TryParse(txtCodigoPostal.Text, out codigoPostal))
            {
                MessageBox.Show("Debes agregar un código postal válido");
                return;
            }

            oLocalidad.Nombre = txtNombre.Text;
            oLocalidad.CodPostal = codigoPostal;

            if (Accion == "A")
                cLOCALIDADES.AgregarLocalidad(oLocalidad);
            if (Accion == "M")
                cLOCALIDADES.ModificarLocalidad(oLocalidad);

            this.DialogResult = DialogResult.OK;
        }
    }
}
