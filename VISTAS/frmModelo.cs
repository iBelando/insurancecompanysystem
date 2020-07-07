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
    public partial class frmModelo : Form
    {
        string Accion;
        MODELO.Modelo oModelo;
        CONTROLADORA.cMODELOS cMODELOS;

        public frmModelo(string miAccion, MODELO.Modelo miModelo)
        {
            InitializeComponent();
            Accion = miAccion;
            oModelo = miModelo;
            cMODELOS = CONTROLADORA.cMODELOS.obtener_instancia();
            cmbMarca.DataSource = cMODELOS.ObtenerMarcas();
            cmbMarca.DisplayMember = "Nombre";
            cmbVersion.DataSource = cMODELOS.ObtenerVersiones();
            cmbVersion.DisplayMember = "Nombre";

            if (Accion != "A")
            {
                txtNombre.Text = oModelo.Nombre;
                cmbMarca.SelectedItem = oModelo.Marca;

                if (Accion == "C")
                {
                    btnGuardar.Visible = false;
                    btnCancelar.Text = "Cerrar";
                    txtNombre.ReadOnly = Enabled;
                    cmbMarca.Enabled = false;
                    cmbVersion.Enabled = false;
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

            MODELO.Version oVersion = (MODELO.Version)cmbVersion.SelectedItem;
            if (oModelo.Versiones.Count(i => i.IdVersion == oVersion.IdVersion) > 0)
            {
                MessageBox.Show("Esta version ya se encuentra agregada en el modelo");
                return;
            }
            oModelo.Versiones.Add(oVersion);

            oModelo.Nombre = txtNombre.Text;
            oModelo.Marca = (MODELO.Marca)cmbMarca.SelectedItem;
            oModelo.IdMarca = oModelo.Marca.IdMarca;

            if (Accion == "A")
                cMODELOS.AgregarModelo(oModelo);
            if (Accion == "M")
                cMODELOS.ModificarModelo(oModelo);

            this.DialogResult = DialogResult.OK;
        }
    }
}
