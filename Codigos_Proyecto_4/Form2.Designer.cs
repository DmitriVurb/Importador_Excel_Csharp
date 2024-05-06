namespace Prueba_04
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFecha));
            this.SeleccionadorFecha = new System.Windows.Forms.DateTimePicker();
            this.LabelFecha = new System.Windows.Forms.Label();
            this.ButtonAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SeleccionadorFecha
            // 
            this.SeleccionadorFecha.Location = new System.Drawing.Point(12, 12);
            this.SeleccionadorFecha.Name = "SeleccionadorFecha";
            this.SeleccionadorFecha.Size = new System.Drawing.Size(400, 22);
            this.SeleccionadorFecha.TabIndex = 0;
            // 
            // LabelFecha
            // 
            this.LabelFecha.AutoSize = true;
            this.LabelFecha.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFecha.Location = new System.Drawing.Point(13, 61);
            this.LabelFecha.Name = "LabelFecha";
            this.LabelFecha.Size = new System.Drawing.Size(116, 24);
            this.LabelFecha.TabIndex = 1;
            this.LabelFecha.Text = "ShowFecha";
            // 
            // ButtonAceptar
            // 
            this.ButtonAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonAceptar.Location = new System.Drawing.Point(228, 184);
            this.ButtonAceptar.Name = "ButtonAceptar";
            this.ButtonAceptar.Size = new System.Drawing.Size(184, 60);
            this.ButtonAceptar.TabIndex = 2;
            this.ButtonAceptar.Text = "Aceptar";
            this.ButtonAceptar.UseVisualStyleBackColor = true;
            // 
            // FormFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 256);
            this.Controls.Add(this.ButtonAceptar);
            this.Controls.Add(this.LabelFecha);
            this.Controls.Add(this.SeleccionadorFecha);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFecha";
            this.Text = "Minicalendario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DateTimePicker SeleccionadorFecha;
        public System.Windows.Forms.Label LabelFecha;
        public System.Windows.Forms.Button ButtonAceptar;
    }
}