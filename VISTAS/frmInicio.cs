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
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void organizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrganizadores formOrganizadores = frmOrganizadores.obtenerInstancia();
            formOrganizadores.Show();
        }

        private void productoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductores formProductores = frmProductores.obtener_instancia();
            formProductores.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes formClientes = frmClientes.obtener_intancia();
            formClientes.Show();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarcas formMarcas = frmMarcas.obtener_instancia();
            formMarcas.Show();
        }

        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModelos formModelos = frmModelos.obtener_instancia();
            formModelos.Show();
        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVehiculos formVehiculos = frmVehiculos.obtener_instancia();
            formVehiculos.Show();
        }

        private void versionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVersiones formVersiones = frmVersiones.obtener_instancia();
            formVersiones.Show();
        }

        private void localidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalidades formLocalidades = frmLocalidades.obtener_instancia();
            formLocalidades.Show();
        }

        private void coberturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCoberturas formCoberturas = frmCoberturas.obtener_instancia();
            formCoberturas.Show();
        }

        private void polizasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPolizas formPolizas = frmPolizas.obtener_instancia();
            formPolizas.Show();
        }
    }
}
