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
    public partial class FormFecha : Form
    {
        public FormFecha()
        {
            InitializeComponent();

            //Modificar el formato del minicalendario
            SeleccionadorFecha.Format = DateTimePickerFormat.Custom;
            SeleccionadorFecha.CustomFormat = "dd/MM/yyyy";

            //Inicializar label para mostrar fecha del minicalendario en el formato deseado
            ShowFecha.Text = "Fecha seleccionada: " + SeleccionadorFecha.Value.ToString("dd/MM/yyyy");

            //ValueChanged (Manejador de Eventos) Se Suscribe (+=) al evento de Fecha_CambiarValor, lo que significa que estará atento a cualquier cambio de ese evento
            SeleccionadorFecha.ValueChanged += Fecha_CambiarValor;

        }

        public void Fecha_CambiarValor(object sender, EventArgs e)
        {
            //Actualiza el label
            ShowFecha.Text = "Fecha seleccionada: " + SeleccionadorFecha.Value.ToString("dd/MM/yyyy");
        }

    }
}
