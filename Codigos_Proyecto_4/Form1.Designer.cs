namespace Prueba_04
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.ButtonEscogerExcel = new System.Windows.Forms.Button();
            this.ButtonImportador = new System.Windows.Forms.Button();
            this.ButtonVaciadoBD = new System.Windows.Forms.Button();
            this.ButtonMostrarMediador = new System.Windows.Forms.Button();
            this.LabelNombre = new System.Windows.Forms.Label();
            this.ButtonMostrarTabla = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonEscogerExcel
            // 
            this.ButtonEscogerExcel.Location = new System.Drawing.Point(12, 12);
            this.ButtonEscogerExcel.Name = "ButtonEscogerExcel";
            this.ButtonEscogerExcel.Size = new System.Drawing.Size(197, 62);
            this.ButtonEscogerExcel.TabIndex = 0;
            this.ButtonEscogerExcel.Text = "Escoger Excel";
            this.ButtonEscogerExcel.UseVisualStyleBackColor = true;
            this.ButtonEscogerExcel.Click += new System.EventHandler(this.ButtonEscogerExcel_Click);
            // 
            // ButtonImportador
            // 
            this.ButtonImportador.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonImportador.Enabled = false;
            this.ButtonImportador.Location = new System.Drawing.Point(591, 12);
            this.ButtonImportador.Name = "ButtonImportador";
            this.ButtonImportador.Size = new System.Drawing.Size(197, 62);
            this.ButtonImportador.TabIndex = 1;
            this.ButtonImportador.Text = "Importación";
            this.ButtonImportador.UseVisualStyleBackColor = true;
            this.ButtonImportador.Click += new System.EventHandler(this.ButtonImportador_Click);
            // 
            // ButtonVaciadoBD
            // 
            this.ButtonVaciadoBD.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonVaciadoBD.Location = new System.Drawing.Point(12, 376);
            this.ButtonVaciadoBD.Name = "ButtonVaciadoBD";
            this.ButtonVaciadoBD.Size = new System.Drawing.Size(197, 62);
            this.ButtonVaciadoBD.TabIndex = 2;
            this.ButtonVaciadoBD.Text = "Vaciar BD";
            this.ButtonVaciadoBD.UseVisualStyleBackColor = true;
            this.ButtonVaciadoBD.Click += new System.EventHandler(this.ButtonVaciadoBD_Click);
            // 
            // ButtonMostrarMediador
            // 
            this.ButtonMostrarMediador.Location = new System.Drawing.Point(298, 12);
            this.ButtonMostrarMediador.Name = "ButtonMostrarMediador";
            this.ButtonMostrarMediador.Size = new System.Drawing.Size(197, 62);
            this.ButtonMostrarMediador.TabIndex = 3;
            this.ButtonMostrarMediador.Text = "Mostrar Mediador";
            this.ButtonMostrarMediador.UseVisualStyleBackColor = true;
            this.ButtonMostrarMediador.Click += new System.EventHandler(this.ButtonMostrarMediador_Click);
            // 
            // LabelNombre
            // 
            this.LabelNombre.AutoSize = true;
            this.LabelNombre.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNombre.Location = new System.Drawing.Point(12, 88);
            this.LabelNombre.Name = "LabelNombre";
            this.LabelNombre.Size = new System.Drawing.Size(215, 24);
            this.LabelNombre.TabIndex = 4;
            this.LabelNombre.Text = "ShowNombreArchivo";
            // 
            // ButtonMostrarTabla
            // 
            this.ButtonMostrarTabla.Location = new System.Drawing.Point(591, 376);
            this.ButtonMostrarTabla.Name = "ButtonMostrarTabla";
            this.ButtonMostrarTabla.Size = new System.Drawing.Size(197, 62);
            this.ButtonMostrarTabla.TabIndex = 5;
            this.ButtonMostrarTabla.Text = "Mostrar Tabla";
            this.ButtonMostrarTabla.UseVisualStyleBackColor = true;
            this.ButtonMostrarTabla.Click += new System.EventHandler(this.ButtonMostrarTabla_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ButtonMostrarTabla);
            this.Controls.Add(this.LabelNombre);
            this.Controls.Add(this.ButtonMostrarMediador);
            this.Controls.Add(this.ButtonVaciadoBD);
            this.Controls.Add(this.ButtonImportador);
            this.Controls.Add(this.ButtonEscogerExcel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPrincipal";
            this.Text = "Ventana Principal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonEscogerExcel;
        private System.Windows.Forms.Button ButtonImportador;
        private System.Windows.Forms.Button ButtonVaciadoBD;
        private System.Windows.Forms.Button ButtonMostrarMediador;
        private System.Windows.Forms.Label LabelNombre;
        private System.Windows.Forms.Button ButtonMostrarTabla;
    }
}

