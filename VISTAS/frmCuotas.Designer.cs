namespace VISTAS
{
    partial class frmCuotas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnPagarCuotas = new System.Windows.Forms.Button();
            this.dgvCuotas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(707, 342);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(112, 43);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnPagarCuotas
            // 
            this.btnPagarCuotas.Location = new System.Drawing.Point(12, 342);
            this.btnPagarCuotas.Name = "btnPagarCuotas";
            this.btnPagarCuotas.Size = new System.Drawing.Size(689, 43);
            this.btnPagarCuotas.TabIndex = 5;
            this.btnPagarCuotas.Text = "Pagar Cuotas";
            this.btnPagarCuotas.UseVisualStyleBackColor = true;
            this.btnPagarCuotas.Click += new System.EventHandler(this.btnPagarCuotas_Click);
            // 
            // dgvCuotas
            // 
            this.dgvCuotas.AllowUserToAddRows = false;
            this.dgvCuotas.AllowUserToDeleteRows = false;
            this.dgvCuotas.AllowUserToOrderColumns = true;
            this.dgvCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuotas.Location = new System.Drawing.Point(12, 12);
            this.dgvCuotas.Name = "dgvCuotas";
            this.dgvCuotas.ReadOnly = true;
            this.dgvCuotas.Size = new System.Drawing.Size(807, 324);
            this.dgvCuotas.TabIndex = 4;
            // 
            // frmCuotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 397);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnPagarCuotas);
            this.Controls.Add(this.dgvCuotas);
            this.Name = "frmCuotas";
            this.Text = "frmCuotas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnPagarCuotas;
        private System.Windows.Forms.DataGridView dgvCuotas;
    }
}