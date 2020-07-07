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
    public partial class frmCobertura : Form
    {
        string Accion;
        MODELO.Cobertura oCobertura;
        CONTROLADORA.cCOBERTURAS cCoberturas;

        public frmCobertura(string miAccion, MODELO.Cobertura miCobertura)
        {
            InitializeComponent();
            Accion = miAccion;
            oCobertura = miCobertura;
            cCoberturas = CONTROLADORA.cCOBERTURAS.obtener_instancia();
            
            if (Accion != "A")
            {
                txtNombre.Text = oCobertura.Nombre;
                nudNumeroCuotas.Value = oCobertura.NroCuotas;
                txtImporteCuota.Text = oCobertura.ImporteCuota.ToString();

                if (Accion == "C")
                {
                    btnGuardar.Visible = false;
                    btnCancelar.Text = "Cerrar";
                    txtNombre.ReadOnly = Enabled;
                    nudNumeroCuotas.Enabled = false;
                    txtImporteCuota.ReadOnly = Enabled;
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
                MessageBox.Show("Debes agregar un nombre de cobertura válida");
                return;
            }
            decimal importe;
            if (!decimal.TryParse(txtImporteCuota.Text, out importe))
            {
                MessageBox.Show("Debes agregar un importe válido");
                return;
            }

            oCobertura.Nombre = txtNombre.Text;
            oCobertura.NroCuotas = int.Parse(nudNumeroCuotas.Text);
            oCobertura.ImporteCuota = importe;

            if (Accion == "A")
                cCoberturas.AgregarCobertura(oCobertura);
            if (Accion == "M")
                cCoberturas.ModificarCobertura(oCobertura);

            this.DialogResult = DialogResult.OK;
        }
    }
}
