namespace Prueba_03
{
    partial class FormFecha
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
            this.SeleccionadorFecha = new System.Windows.Forms.DateTimePicker();
            this.ShowFecha = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SeleccionadorFecha
            // 
            this.SeleccionadorFecha.Location = new System.Drawing.Point(13, 13);
            this.SeleccionadorFecha.Name = "SeleccionadorFecha";
            this.SeleccionadorFecha.Size = new System.Drawing.Size(421, 22);
            this.SeleccionadorFecha.TabIndex = 0;
            // 
            // ShowFecha
            // 
            this.ShowFecha.AutoSize = true;
            this.ShowFecha.Location = new System.Drawing.Point(13, 51);
            this.ShowFecha.Name = "ShowFecha";
            this.ShowFecha.Size = new System.Drawing.Size(78, 16);
            this.ShowFecha.TabIndex = 1;
            this.ShowFecha.Text = "ShowFecha";
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(295, 145);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(139, 45);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // FormFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 202);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.ShowFecha);
            this.Controls.Add(this.SeleccionadorFecha);
            this.Name = "FormFecha";
            this.Text = "Minicalendario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DateTimePicker SeleccionadorFecha;
        private System.Windows.Forms.Label ShowFecha;
        private System.Windows.Forms.Button btnAceptar;
    }
}