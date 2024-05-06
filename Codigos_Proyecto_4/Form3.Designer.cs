namespace Prueba_04
{
    partial class FormResultado
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResultado));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bD_ImportadorDataSet = new Prueba_04.BD_ImportadorDataSet();
            this.listaregistrosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lista_registrosTableAdapter = new Prueba_04.BD_ImportadorDataSetTableAdapters.lista_registrosTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecharegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plazoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diasplazoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monedaColumnaCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monedaColumnaEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aSKmonedaCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aSKmonedaEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bIDmonedaCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bIDmonedaEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bD_ImportadorDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaregistrosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.fecharegistroDataGridViewTextBoxColumn,
            this.plazoDataGridViewTextBoxColumn,
            this.diasplazoDataGridViewTextBoxColumn,
            this.monedaColumnaCDataGridViewTextBoxColumn,
            this.monedaColumnaEDataGridViewTextBoxColumn,
            this.aSKmonedaCDataGridViewTextBoxColumn,
            this.aSKmonedaEDataGridViewTextBoxColumn,
            this.bIDmonedaCDataGridViewTextBoxColumn,
            this.bIDmonedaEDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.listaregistrosBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1764, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // bD_ImportadorDataSet
            // 
            this.bD_ImportadorDataSet.DataSetName = "BD_ImportadorDataSet";
            this.bD_ImportadorDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listaregistrosBindingSource
            // 
            this.listaregistrosBindingSource.DataMember = "lista_registros";
            this.listaregistrosBindingSource.DataSource = this.bD_ImportadorDataSet;
            // 
            // lista_registrosTableAdapter
            // 
            this.lista_registrosTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // fecharegistroDataGridViewTextBoxColumn
            // 
            this.fecharegistroDataGridViewTextBoxColumn.DataPropertyName = "fecha_registro";
            this.fecharegistroDataGridViewTextBoxColumn.HeaderText = "fecha_registro";
            this.fecharegistroDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fecharegistroDataGridViewTextBoxColumn.Name = "fecharegistroDataGridViewTextBoxColumn";
            this.fecharegistroDataGridViewTextBoxColumn.Width = 125;
            // 
            // plazoDataGridViewTextBoxColumn
            // 
            this.plazoDataGridViewTextBoxColumn.DataPropertyName = "plazo";
            this.plazoDataGridViewTextBoxColumn.HeaderText = "plazo";
            this.plazoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.plazoDataGridViewTextBoxColumn.Name = "plazoDataGridViewTextBoxColumn";
            this.plazoDataGridViewTextBoxColumn.Width = 125;
            // 
            // diasplazoDataGridViewTextBoxColumn
            // 
            this.diasplazoDataGridViewTextBoxColumn.DataPropertyName = "dias_plazo";
            this.diasplazoDataGridViewTextBoxColumn.HeaderText = "dias_plazo";
            this.diasplazoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.diasplazoDataGridViewTextBoxColumn.Name = "diasplazoDataGridViewTextBoxColumn";
            this.diasplazoDataGridViewTextBoxColumn.Width = 125;
            // 
            // monedaColumnaCDataGridViewTextBoxColumn
            // 
            this.monedaColumnaCDataGridViewTextBoxColumn.DataPropertyName = "Moneda_ColumnaC";
            this.monedaColumnaCDataGridViewTextBoxColumn.HeaderText = "Moneda_ColumnaC";
            this.monedaColumnaCDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.monedaColumnaCDataGridViewTextBoxColumn.Name = "monedaColumnaCDataGridViewTextBoxColumn";
            this.monedaColumnaCDataGridViewTextBoxColumn.Width = 125;
            // 
            // monedaColumnaEDataGridViewTextBoxColumn
            // 
            this.monedaColumnaEDataGridViewTextBoxColumn.DataPropertyName = "Moneda_ColumnaE";
            this.monedaColumnaEDataGridViewTextBoxColumn.HeaderText = "Moneda_ColumnaE";
            this.monedaColumnaEDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.monedaColumnaEDataGridViewTextBoxColumn.Name = "monedaColumnaEDataGridViewTextBoxColumn";
            this.monedaColumnaEDataGridViewTextBoxColumn.Width = 125;
            // 
            // aSKmonedaCDataGridViewTextBoxColumn
            // 
            this.aSKmonedaCDataGridViewTextBoxColumn.DataPropertyName = "ASK_monedaC";
            this.aSKmonedaCDataGridViewTextBoxColumn.HeaderText = "ASK_monedaC";
            this.aSKmonedaCDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.aSKmonedaCDataGridViewTextBoxColumn.Name = "aSKmonedaCDataGridViewTextBoxColumn";
            this.aSKmonedaCDataGridViewTextBoxColumn.Width = 125;
            // 
            // aSKmonedaEDataGridViewTextBoxColumn
            // 
            this.aSKmonedaEDataGridViewTextBoxColumn.DataPropertyName = "ASK_monedaE";
            this.aSKmonedaEDataGridViewTextBoxColumn.HeaderText = "ASK_monedaE";
            this.aSKmonedaEDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.aSKmonedaEDataGridViewTextBoxColumn.Name = "aSKmonedaEDataGridViewTextBoxColumn";
            this.aSKmonedaEDataGridViewTextBoxColumn.Width = 125;
            // 
            // bIDmonedaCDataGridViewTextBoxColumn
            // 
            this.bIDmonedaCDataGridViewTextBoxColumn.DataPropertyName = "BID_monedaC";
            this.bIDmonedaCDataGridViewTextBoxColumn.HeaderText = "BID_monedaC";
            this.bIDmonedaCDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.bIDmonedaCDataGridViewTextBoxColumn.Name = "bIDmonedaCDataGridViewTextBoxColumn";
            this.bIDmonedaCDataGridViewTextBoxColumn.Width = 125;
            // 
            // bIDmonedaEDataGridViewTextBoxColumn
            // 
            this.bIDmonedaEDataGridViewTextBoxColumn.DataPropertyName = "BID_monedaE";
            this.bIDmonedaEDataGridViewTextBoxColumn.HeaderText = "BID_monedaE";
            this.bIDmonedaEDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.bIDmonedaEDataGridViewTextBoxColumn.Name = "bIDmonedaEDataGridViewTextBoxColumn";
            this.bIDmonedaEDataGridViewTextBoxColumn.Width = 125;
            // 
            // FormResultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1788, 450);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormResultado";
            this.Text = "Vista de la BD";
            this.Load += new System.EventHandler(this.FormResultado_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bD_ImportadorDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaregistrosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private BD_ImportadorDataSet bD_ImportadorDataSet;
        private System.Windows.Forms.BindingSource listaregistrosBindingSource;
        private BD_ImportadorDataSetTableAdapters.lista_registrosTableAdapter lista_registrosTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecharegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plazoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diasplazoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monedaColumnaCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monedaColumnaEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aSKmonedaCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aSKmonedaEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bIDmonedaCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bIDmonedaEDataGridViewTextBoxColumn;
    }
}