using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_03
{
    public partial class FormResultado : Form
    {
        public FormResultado()
        {
            InitializeComponent();
        }

        public void MostrarDatosGridView()
        {
            using (var context = new BD_ImportadorEntities())
            {
                dataGridView1.DataSource = context.lista_registros.ToList();
            }
        }

        private void FormResultado_Load(object sender, EventArgs e)
        {
            MostrarDatosGridView();
        }
    }
}
