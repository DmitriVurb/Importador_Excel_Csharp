namespace Prueba_03
{
    partial class VentanaPrincipal
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
            this.buttonPreparacion = new System.Windows.Forms.Button();
            this.buttonTruncador = new System.Windows.Forms.Button();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.ShowRuta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonPreparacion
            // 
            this.buttonPreparacion.Location = new System.Drawing.Point(12, 12);
            this.buttonPreparacion.Name = "buttonPreparacion";
            this.buttonPreparacion.Size = new System.Drawing.Size(181, 57);
            this.buttonPreparacion.TabIndex = 0;
            this.buttonPreparacion.Text = "Prueba";
            this.buttonPreparacion.UseVisualStyleBackColor = true;
            this.buttonPreparacion.Click += new System.EventHandler(this.buttonPreparacion_Click);
            // 
            // buttonTruncador
            // 
            this.buttonTruncador.Location = new System.Drawing.Point(607, 12);
            this.buttonTruncador.Name = "buttonTruncador";
            this.buttonTruncador.Size = new System.Drawing.Size(181, 56);
            this.buttonTruncador.TabIndex = 1;
            this.buttonTruncador.Text = "Truncar";
            this.buttonTruncador.UseVisualStyleBackColor = true;
            this.buttonTruncador.Click += new System.EventHandler(this.buttonTruncador_Click);
            // 
            // buttonExcel
            // 
            this.buttonExcel.Location = new System.Drawing.Point(12, 381);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(181, 57);
            this.buttonExcel.TabIndex = 2;
            this.buttonExcel.Text = "Escoger Excel";
            this.buttonExcel.UseVisualStyleBackColor = true;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // ShowRuta
            // 
            this.ShowRuta.AutoSize = true;
            this.ShowRuta.Location = new System.Drawing.Point(9, 82);
            this.ShowRuta.Name = "ShowRuta";
            this.ShowRuta.Size = new System.Drawing.Size(68, 16);
            this.ShowRuta.TabIndex = 3;
            this.ShowRuta.Text = "ShowRuta";
            // 
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ShowRuta);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.buttonTruncador);
            this.Controls.Add(this.buttonPreparacion);
            this.Name = "VentanaPrincipal";
            this.Text = "Inicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPreparacion;
        private System.Windows.Forms.Button buttonTruncador;
        private System.Windows.Forms.Button buttonExcel;
        private System.Windows.Forms.Label ShowRuta;
    }
}

