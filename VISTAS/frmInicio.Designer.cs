namespace VISTAS
{
    partial class frmInicio
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gESTIONARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sALIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organizadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gESTIONARVEHICULOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehiculosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gESTIONAROTROSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coberturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polizasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gESTIONARToolStripMenuItem,
            this.gESTIONARVEHICULOSToolStripMenuItem,
            this.gESTIONAROTROSToolStripMenuItem,
            this.sALIRToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(513, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gESTIONARToolStripMenuItem
            // 
            this.gESTIONARToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.organizadoresToolStripMenuItem,
            this.productoresToolStripMenuItem,
            this.clientesToolStripMenuItem});
            this.gESTIONARToolStripMenuItem.Name = "gESTIONARToolStripMenuItem";
            this.gESTIONARToolStripMenuItem.Size = new System.Drawing.Size(143, 20);
            this.gESTIONARToolStripMenuItem.Text = "GESTIONAR PERSONAS";
            // 
            // sALIRToolStripMenuItem
            // 
            this.sALIRToolStripMenuItem.Name = "sALIRToolStripMenuItem";
            this.sALIRToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sALIRToolStripMenuItem.Text = "SALIR";
            this.sALIRToolStripMenuItem.Click += new System.EventHandler(this.sALIRToolStripMenuItem_Click);
            // 
            // organizadoresToolStripMenuItem
            // 
            this.organizadoresToolStripMenuItem.Name = "organizadoresToolStripMenuItem";
            this.organizadoresToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.organizadoresToolStripMenuItem.Text = "Organizadores";
            this.organizadoresToolStripMenuItem.Click += new System.EventHandler(this.organizadoresToolStripMenuItem_Click);
            // 
            // productoresToolStripMenuItem
            // 
            this.productoresToolStripMenuItem.Name = "productoresToolStripMenuItem";
            this.productoresToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.productoresToolStripMenuItem.Text = "Productores";
            this.productoresToolStripMenuItem.Click += new System.EventHandler(this.productoresToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // gESTIONARVEHICULOSToolStripMenuItem
            // 
            this.gESTIONARVEHICULOSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marcasToolStripMenuItem,
            this.modelosToolStripMenuItem,
            this.vehiculosToolStripMenuItem,
            this.versionesToolStripMenuItem});
            this.gESTIONARVEHICULOSToolStripMenuItem.Name = "gESTIONARVEHICULOSToolStripMenuItem";
            this.gESTIONARVEHICULOSToolStripMenuItem.Size = new System.Drawing.Size(147, 20);
            this.gESTIONARVEHICULOSToolStripMenuItem.Text = "GESTIONAR VEHICULOS";
            // 
            // marcasToolStripMenuItem
            // 
            this.marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            this.marcasToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.marcasToolStripMenuItem.Text = "Marcas";
            this.marcasToolStripMenuItem.Click += new System.EventHandler(this.marcasToolStripMenuItem_Click);
            // 
            // modelosToolStripMenuItem
            // 
            this.modelosToolStripMenuItem.Name = "modelosToolStripMenuItem";
            this.modelosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.modelosToolStripMenuItem.Text = "Modelos";
            this.modelosToolStripMenuItem.Click += new System.EventHandler(this.modelosToolStripMenuItem_Click);
            // 
            // vehiculosToolStripMenuItem
            // 
            this.vehiculosToolStripMenuItem.Name = "vehiculosToolStripMenuItem";
            this.vehiculosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.vehiculosToolStripMenuItem.Text = "Vehiculos";
            this.vehiculosToolStripMenuItem.Click += new System.EventHandler(this.vehiculosToolStripMenuItem_Click);
            // 
            // versionesToolStripMenuItem
            // 
            this.versionesToolStripMenuItem.Name = "versionesToolStripMenuItem";
            this.versionesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.versionesToolStripMenuItem.Text = "Versiones";
            this.versionesToolStripMenuItem.Click += new System.EventHandler(this.versionesToolStripMenuItem_Click);
            // 
            // gESTIONAROTROSToolStripMenuItem
            // 
            this.gESTIONAROTROSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localidadesToolStripMenuItem,
            this.coberturasToolStripMenuItem,
            this.polizasToolStripMenuItem});
            this.gESTIONAROTROSToolStripMenuItem.Name = "gESTIONAROTROSToolStripMenuItem";
            this.gESTIONAROTROSToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.gESTIONAROTROSToolStripMenuItem.Text = "GESTIONAR OTROS";
            // 
            // localidadesToolStripMenuItem
            // 
            this.localidadesToolStripMenuItem.Name = "localidadesToolStripMenuItem";
            this.localidadesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.localidadesToolStripMenuItem.Text = "Localidades";
            this.localidadesToolStripMenuItem.Click += new System.EventHandler(this.localidadesToolStripMenuItem_Click);
            // 
            // coberturasToolStripMenuItem
            // 
            this.coberturasToolStripMenuItem.Name = "coberturasToolStripMenuItem";
            this.coberturasToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.coberturasToolStripMenuItem.Text = "Coberturas";
            this.coberturasToolStripMenuItem.Click += new System.EventHandler(this.coberturasToolStripMenuItem_Click);
            // 
            // polizasToolStripMenuItem
            // 
            this.polizasToolStripMenuItem.Name = "polizasToolStripMenuItem";
            this.polizasToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.polizasToolStripMenuItem.Text = "Polizas";
            this.polizasToolStripMenuItem.Click += new System.EventHandler(this.polizasToolStripMenuItem_Click);
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 41);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmInicio";
            this.Text = "frmInicio";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gESTIONARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem organizadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gESTIONARVEHICULOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vehiculosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gESTIONAROTROSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coberturasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polizasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sALIRToolStripMenuItem;
    }
}