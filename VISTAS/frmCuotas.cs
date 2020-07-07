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
    public partial class frmCuotas : Form
    {
        MODELO.Poliza oPoliza;
        CONTROLADORA.cPOLIZAS cPOLIZAS;

        public frmCuotas(MODELO.Poliza miPoliza)
        {
            InitializeComponent();
            cPOLIZAS = CONTROLADORA.cPOLIZAS.obtener_instancia();
            oPoliza = miPoliza;
            ArmarGrilla();
        }

        public void ArmarGrilla()
        {
            dgvCuotas.DataSource = null;
            dgvCuotas.DataSource = cPOLIZAS.ObtenerCuotas(oPoliza);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPagarCuotas_Click(object sender, EventArgs e)
        {
            if (dgvCuotas.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una cuota");
                return;
            }
            MODELO.Poliza oPoliza = cPOLIZAS.ObtenerPoliza(Convert.ToInt32(dgvCuotas.CurrentRow.Cells[0].Value));
        }
    }
}
