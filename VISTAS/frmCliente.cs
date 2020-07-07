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
    public partial class frmCliente : Form
    {
        string Accion;
        MODELO.Cliente oCliente;
        CONTROLADORA.cCLIENTES cClientes;

        public frmCliente(string miAccion, MODELO.Cliente miCliente)
        {
            InitializeComponent();
            Accion = miAccion;
            oCliente = miCliente;
            cClientes = CONTROLADORA.cCLIENTES.obtener_instancia();
            cmbLocalidad.DataSource = cClientes.ObtenerLocalidades();
            cmbLocalidad.SelectedIndex = 0;
            
            if (Accion != "A")
            {
                txtNombre.Text = oCliente.Nombre;
                txtApellido.Text = oCliente.Apellido;
                txtDNI.Text = oCliente.DNI.ToString();
                txtCuil.Text = oCliente.CUIL.ToString();
                txtCUIT.Text = oCliente.CUIT.ToString();
                nudEdad.Value = oCliente.Edad;
                txtEmail.Text = oCliente.Email;
                txtCelular.Text = oCliente.Celular.ToString();
                txtDireccion.Text = oCliente.Direccion;
                cmbLocalidad.SelectedItem = oCliente.IdLocalidad;

                if (Accion == "C")
                {
                    btnGuardar.Visible = false;
                    btnCancelar.Text = "Cerrar";
                    txtNombre.ReadOnly = Enabled;
                    txtApellido.ReadOnly = Enabled;
                    txtDNI.ReadOnly = Enabled;
                    txtCuil.ReadOnly = Enabled;
                    txtCUIT.ReadOnly = Enabled;
                    nudEdad.Enabled = false;
                    txtEmail.ReadOnly = Enabled;
                    txtCelular.ReadOnly = Enabled;
                    txtDireccion.ReadOnly = Enabled;
                    cmbLocalidad.Enabled = false;
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
                MessageBox.Show("Debes completar con un nombre válido");
                return;
            }
            if(string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Debes completar con un apellido válido");
                return;
            }
            int dni;
            if(!int.TryParse(txtDNI.Text, out dni))
            {
                MessageBox.Show("Debes completar con un DNI válido");
                return;
            }
            int cuil;
            if(!int.TryParse(txtCuil.Text, out cuil))
            {
                MessageBox.Show("Dbes completar con un CUIL válido");
                return;
            }
            int cuit;
            if(!int.TryParse(txtCUIT.Text, out cuit))
            {
                MessageBox.Show("Debes completar con un CUIT válido");
                return;
            }
            if(string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Debes completar con un email válido");
                return;
            }
            int telefono;
            if(!int.TryParse(txtCelular.Text, out telefono))
            {
                MessageBox.Show("Debes completar con un teléfono válido");
                return;
            }
            if(string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("Debes completar con una dirección válida");
                return;
            }

            oCliente.Nombre = txtNombre.Text;
            oCliente.Apellido = txtApellido.Text;
            oCliente.DNI = dni;
            oCliente.CUIL = cuil;
            oCliente.CUIT = cuit;
            oCliente.Edad = Convert.ToInt32(nudEdad.Value);
            oCliente.Email = txtEmail.Text;
            oCliente.Celular = telefono;
            oCliente.Direccion = txtDireccion.Text;
            oCliente.IdLocalidad = (MODELO.Localidad)cmbLocalidad.SelectedItem;

            if (Accion == "A")
                cClientes.AgregarCliente(oCliente);
            if (Accion == "M")
                cClientes.ModificarCliente(oCliente);

            this.DialogResult = DialogResult.OK;
        }
    }
}
