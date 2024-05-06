using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics.Eventing.Reader;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Prueba_04
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();

            this.BackgroundImage = Image.FromFile(@"C:\Users\Dmitri\Pictures\Saved Pictures\Roz.jpg");

            this.BackgroundImageLayout = ImageLayout.Stretch;

            LabelNombre.Text = "Todavia se ha seleccionado el archivo";

            DatosExcelCambiados += ActualizarLabelConDatosExcel;

            LabelNombre.TextChanged += LabelNombre_TextChanged;
        }

        public delegate void DatosExcelCambiadosDelegate(string[] nuevosDatos);
        public event DatosExcelCambiadosDelegate DatosExcelCambiados;

        public void LabelNombre_TextChanged(object sender, EventArgs e)
        {
            if (LabelNombre.Text != "No hay archivo escogido" && !string.IsNullOrEmpty(LabelNombre.Text))
            {
                ButtonImportador.Enabled = true; // Habilitar el botón de importación
            }
            else
            {
                ButtonImportador.Enabled = false; // Deshabilitar el botón de importación
            }
        }

        public void ActualizarLabelConDatosExcel(string[] nuevosDatos)
        {
            if(InvokeRequired)
            {
                Invoke(new Action(() => ActualizarLabelConDatosExcel(nuevosDatos)));
            }
            else
            {
                LabelNombre.Text = nuevosDatos != null && nuevosDatos.Length > 0 ? nuevosDatos[1] : "No hay archivo escogido";
            }
        }

        private void AbrirFormResultado()
        {
            FormResultado formResultado = new FormResultado();

            formResultado.Show();            
        }

/////BOTONES/////////////////////////////////////////////////////////////////////////////////////////////

        private void ButtonEscogerExcel_Click(object sender, EventArgs e)
        {
            EscogerExcel();            

            if (sender is System.Windows.Forms.Button btn && btn.Text == "Escoger Excel")
            {
                btn.Text = "¿Escoger otro?";
            }
        }

        private void ButtonImportador_Click(object sender, EventArgs e)
        {
            RegistrarObjetos();
            AbrirFormResultado();
        }

        private void ButtonVaciadoBD_Click(object sender, EventArgs e)
        {
            TruncarTablaConSQL();
            AbrirFormResultado();
        }

        private void ButtonMostrarMediador_Click(object sender, EventArgs e)
        {
            MostrarMediador();
        }

        private void ButtonMostrarTabla_Click(object sender, EventArgs e)
        {
            AbrirFormResultado();
        }

/////REQUERIMIENTOS 1° PARA BOTON "ESCOGER EXCEL"/////////////////////////////////////////////////////////////////////////////////////////////

        public string[] datosExcel;

        public string RutaSeleccionada
        {
            get { return datosExcel != null && datosExcel.Length > 0 ? datosExcel[0] : null; }
        }

        public string FechaSeleccionada
        {
            get { return datosExcel != null && datosExcel.Length > 0 ? datosExcel[2] : null; }
        }
        
        public void EscogerExcel()
        {
            string fechaSeleccionada;
            string rutaArchivo;
            string nombreArchivo;
            string fechaArchivo;
            bool solicitarFechaNuevamente = false;

            do
            {
                using (var formFecha = new FormFecha())
                {
                    if (formFecha.ShowDialog() == DialogResult.OK)
                    {
                        fechaSeleccionada = formFecha.SeleccionadorFecha.Value.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        MessageBox.Show("Se cancela la carga del archivo");
                        datosExcel = null;
                        DatosExcelCambiados?.Invoke(datosExcel);
                        return;
                    }
                }

                using (OpenFileDialog abrir = new OpenFileDialog())
                {
                    abrir.Filter = "Archivos Excel (*.xlsx)|*.xlsx|Hoja de cálculo de Microsoft Excel (.xls)|*.xls";
                    abrir.FilterIndex = 2;
                    if(abrir.ShowDialog() == DialogResult.OK)
                    {
                        rutaArchivo = abrir.FileName;
                        nombreArchivo = Path.GetFileNameWithoutExtension(abrir.FileName);

                        var regex = new Regex(@"^prueba_(\d{2})_(\d{2})_(\d{4})$");
                        var match = regex.Match(nombreArchivo);

                        if (match.Success)
                        {
                            string dia = match.Groups[1].Value;
                            string mes = match.Groups[2].Value;
                            string año = match.Groups[3].Value;

                            fechaArchivo = $"{año}-{mes}-{dia}";

                            if (fechaArchivo != fechaSeleccionada)
                            {
                                var resultado = MessageBox.Show("La fecha seleccionada en el minicalendario no concuerda con la fecha del archivo, ¿Desea intentar arreglarlo?", "Fecha No Concuerda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (resultado == DialogResult.No)
                                {
                                    datosExcel = null;
                                    DatosExcelCambiados?.Invoke(datosExcel);
                                    return;
                                }

                                CustomMessageBox cmb = new CustomMessageBox("¿Desea seleccionar otra fecha en el minicalendario o desea modificar la fecha del archivo?", "Modificar Fecha");
                                DialogResult result = cmb.ShowDialog();
                                if (result == DialogResult.Cancel)
                                {
                                    datosExcel = null;
                                    DatosExcelCambiados?.Invoke(datosExcel);
                                    return;
                                }

                                else if (result == DialogResult.Yes)
                                {
                                    solicitarFechaNuevamente = true;
                                    continue;
                                }
                                else
                                {
                                    string nuevaFecha = Prompt.ShowDialog("Modificar Fecha del Archivo");

                                    if (!string.IsNullOrEmpty(nuevaFecha))
                                    { 
                                        if (nuevaFecha == fechaSeleccionada)
                                        {
                                            DateTime fecha = DateTime.ParseExact(nuevaFecha, "yyyy-MM-dd", CultureInfo.InvariantCulture);                                          
                                            
                                            string nuevaRuta = Path.GetDirectoryName(rutaArchivo);
                                            string extension = Path.GetExtension(rutaArchivo);                                            

                                            string nuevoNombre = $"prueba_{fecha.Day:00}_{fecha.Month:00}_{fecha.Year}{extension}";
                                            string nombrePuroNuevo = $"prueba_{fecha.Day:00}_{fecha.Month:00}_{fecha.Year}";
                                            string rutaCompletaNueva = Path.Combine(nuevaRuta, nuevoNombre);

                                            string nuevaFechaSeleccionada = $"{fecha.Year}-{fecha.Month:00}-{fecha.Day:00}";

                                            try
                                            {
                                                if (System.IO.File.Exists(rutaCompletaNueva))
                                                {
                                                    MessageBox.Show("Un archivo con el mismo nombre ya existe");
                                                    datosExcel = null;
                                                    DatosExcelCambiados?.Invoke(datosExcel);
                                                    return;
                                                }

                                                System.IO.File.Move(rutaArchivo, rutaCompletaNueva);                                                
                                                MessageBox.Show($"Archivo renombrado a: {nuevoNombre}");

                                                datosExcel = new string[] { rutaCompletaNueva, nombrePuroNuevo, nuevaFechaSeleccionada };
                                                MessageBox.Show("Archivo seleccionado exitosamente, EXITO");
                                                DatosExcelCambiados?.Invoke(datosExcel);
                                                return;
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show($"Error al renombar el archivo: {ex.Message}");
                                                datosExcel = null;
                                                DatosExcelCambiados?.Invoke(datosExcel);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Las fechas no concuerdan. Cancelando proceso");
                                            datosExcel = null;
                                            DatosExcelCambiados?.Invoke(datosExcel);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se seleccionó ninguna fecha");
                                        datosExcel = null;
                                        DatosExcelCambiados?.Invoke(datosExcel);
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                datosExcel = new string[] { rutaArchivo, nombreArchivo, fechaArchivo };
                                MessageBox.Show("Archivo seleccionado exitosamente, EXITO");
                                DatosExcelCambiados?.Invoke(datosExcel);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("El archivo NO cumple con el formato de DD/MM/AAAA");
                            datosExcel = null;
                            DatosExcelCambiados?.Invoke(datosExcel);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se escogió ningún archivo, se cancela la carga");
                        datosExcel = null;
                        DatosExcelCambiados?.Invoke(datosExcel);
                    }
                }
            } while (solicitarFechaNuevamente);
            DatosExcelCambiados?.Invoke(datosExcel);
        }

/////REQUERIMIENTOS 3° PARA BOTON "ESCOGER EXCEL"/////////////////////////////////////////////////////////////////////////////////////////////



/////VINDICADORES/////////////////////////////////////////////////////////////////////////////////////////////

        public bool Vindicador1(string ruta, string fecha)
        {
            if (ruta != null && fecha != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Vindicador2(string cadena)
        {
            string patron = @"^\d[YMW]$";

            Regex regex = new Regex(patron);

            return regex.IsMatch(cadena);
        }

/////MOSTRADOR DE VINDICADORES/////////////////////////////////////////////////////////////////////////////////////////////







/////FUNCIONES PARA BOTON "MOSTRAR MEDIADOR"/////////////////////////////////////////////////////////////////////////////////////////////

        public void MostrarMediador()
        {
            string archivo = AppDomain.CurrentDomain.BaseDirectory;

            string rutaArchivo = Path.Combine(archivo, "Mediador.txt");

            try
            {
                Process.Start(new ProcessStartInfo(rutaArchivo) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo abrir el archivo. Error: " + ex.Message);
            }
        }

/////FUNCIONES PARA BOTON "IMPORTACIÓN"/////////////////////////////////////////////////////////////////////////////////////////////

        public void RegistrarObjetos()
        {
            IWorkbook excel = ObtenerWorkbook(RutaSeleccionada);
            if (excel == null)
            {
                MessageBox.Show("No se pudo cargar el archivo Excel.");
                return;
            }

            int cantidadHojas = ObtenerCantidadHojasExcel(excel);
            for (int i = 0; i < cantidadHojas; i++)
            {
                List<string> plazosValidosAsk = ObtenerPlazosValidosASK(excel, i);
                List<string> plazosValidosBid = ObtenerPlazosValidosBID(excel, i);
                List<string> plazosDefinitivos = ObtenerListaDefinitivaDePlazos(plazosValidosAsk, plazosValidosBid);

                foreach (string plazo in plazosDefinitivos)
                {
                    int indexAsk = plazosValidosAsk.IndexOf(plazo);
                    int indexBid = plazosValidosBid.IndexOf(plazo);
                    if (indexAsk != -1 && indexBid != -1)
                    {
                        try
                        {

                        
                        int filaAsk = FilasValidasASK[indexAsk];
                        int filaBid = FilasValidasBID[indexBid];
                        int diasPlazo = ObtenerConversionPlazoInt(plazo);
                        string monedaC = ObtenerPrimeraMitadNombreHoja(excel, i);
                        string monedaE = ObtenerSegundaMitadNombreHoja(excel, i);

                        double contenedor1 = ObtenerValorCeldaDeterminadaNumero(excel, i, filaAsk, 2);
                        double contenedor2 = ObtenerValorCeldaDeterminadaNumero(excel, i, filaAsk, 4);
                        double contenedor3 = ObtenerValorCeldaDeterminadaNumero(excel, i, filaBid, 2);
                        double contenedor4 = ObtenerValorCeldaDeterminadaNumero(excel, i, filaBid, 4);


                        var nuevoRegistro = new lista_registros()
                        {
                            fecha_registro = DateTime.Parse(FechaSeleccionada),
                            plazo = plazo,
                            dias_plazo = diasPlazo,
                            Moneda_ColumnaC = monedaC,
                            Moneda_ColumnaE = monedaE,
                            ASK_monedaC = contenedor1,
                            ASK_monedaE = contenedor2,
                            BID_monedaC = contenedor3,
                            BID_monedaE = contenedor4
                        };
                            using (var context = new BD_ImportadorEntities())
                            {
                                context.lista_registros.Add(nuevoRegistro);
                                context.SaveChanges();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"No se pudo registrar el plazo '{plazo}' debido a: {ex.Message}");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"No se encontraron índices válidos para ASK o BID del plazo '{plazo}'. ASK: {indexAsk}, BID: {indexBid}");
                    }
                }
            }
        }

/////FUNCIONES PARA BOTON "VACIAR DB"/////////////////////////////////////////////////////////////////////////////////////////////

        public void TruncarTablaConSQL()
        {
            using (var context = new BD_ImportadorEntities())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE lista_registros");
                MessageBox.Show("Tabla truncada con éxito (SQL)");
            }
        }

/////FUNCIONES AUXILIARES/////////////////////////////////////////////////////////////////////////////////////////////

        public IWorkbook ObtenerWorkbook(string archivo)
        {
            try
            {
                IWorkbook workbook;

                using (var stream = new FileStream(archivo, FileMode.Open, FileAccess.Read))
                {
                    if (archivo.EndsWith(".xlsx"))
                    {
                        workbook = new XSSFWorkbook(stream);
                        return workbook;
                    }
                    else if (archivo.EndsWith(".xls"))
                    {
                        workbook = new HSSFWorkbook(stream);
                        return workbook;
                    }
                    else
                    {
                        MessageBox.Show("Formato de archivo no soportado.");
                        return null;
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Archivo no encontrado: {archivo} - {ex.Message}");
                return null;
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error al leer el archivo. Podría estar en uso otra aplicación. - {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el archivo: {ex.Message}");
                return null;
            }
        }

        public int ObtenerCantidadHojasExcel(IWorkbook workbook)
        {
            return workbook.NumberOfSheets;
        }

        public string ObtenerValorCeldaDeterminadaCadena(IWorkbook workbook, int nHoja, int nFila, int nColumna)
        {
            ISheet hoja = workbook.GetSheetAt(nHoja);
            IRow fila = hoja.GetRow(nFila);
            ICell celda = fila.GetCell(nColumna);

            return celda.ToString();
        }

        public double ObtenerValorCeldaDeterminadaNumero(IWorkbook workbook, int nHoja, int nFila, int nColumna)
        {
            ISheet hoja = workbook.GetSheetAt(nHoja);
            IRow fila = hoja.GetRow(nFila);
            ICell celda = fila.GetCell(nColumna);

            return celda.NumericCellValue;
        }

        public List<int> ObtenerFilasValidasExcel(IWorkbook workbook, int hojaDeterminada)
        {
            var filasValidas = new List<int>();

            if (workbook == null)
            {
                throw new ArgumentException("El objeto workbook proporcionado es nulo.");
            }
            try
            {
                ISheet hoja = workbook.GetSheetAt(hojaDeterminada);
                bool encontradoDate = false;

                for (int rowIndex = 0; rowIndex <= hoja.LastRowNum; rowIndex++)
                {
                    IRow fila = hoja.GetRow(rowIndex);
                    if (fila != null)
                    {
                        ICell celda = fila.GetCell(0);//Primera Columna Siempre
                        if (celda != null && celda.CellType == CellType.String)
                        {
                            string celdaValue = celda.StringCellValue;
                            if (!encontradoDate && celdaValue.Trim().ToUpper() == "DATE")
                            {
                                encontradoDate = true;  // Marcar que hemos encontrado el primer "DATE"
                                continue;
                            }
                            else if (encontradoDate && Vindicador2(celdaValue))
                            {
                                filasValidas.Add(rowIndex);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return filasValidas;
        }

        public int ObtenerConversionPlazoInt(string plazo)
        {
            if (string.IsNullOrEmpty(plazo))
            {
                throw new ArgumentException("El plazo proporcionado está vacío o es nulo.");
            }

            int numeroPlazo = int.Parse(plazo.Substring(0, plazo.Length - 1));
            char letraPlazo = plazo[plazo.Length - 1];

            switch (letraPlazo)
            {
                case 'Y': // Años
                    return numeroPlazo * 360; // Suponiendo que cada año tiene 360 días
                case 'M': // Meses
                    return numeroPlazo * 30;  // Suponiendo que cada mes tiene 30 días
                case 'W': // Semanas
                    return numeroPlazo * 7;   // Cada semana tiene 7 días
                default:
                    throw new ArgumentException("Unidad de tiempo desconocida en el plazo.");
            }
        }

        public string ObtenerPrimeraMitadNombreHoja(IWorkbook workbook, int nHoja)
        {
            ISheet hoja = workbook.GetSheetAt(nHoja);
            string nombreHoja = hoja.SheetName;
            string primeraMitad = nombreHoja.Substring(0, 3);

            return primeraMitad;
        }

        public string ObtenerSegundaMitadNombreHoja(IWorkbook workbook, int nHoja)
        {
            ISheet hoja = workbook.GetSheetAt(nHoja);
            string nombreHoja = hoja.SheetName;
            string segundaMitad = nombreHoja.Substring(nombreHoja.Length - 3);

            return segundaMitad;
        }

        public int ObtenerPosicionPrimerDate(IWorkbook workbook, int nHoja)
        {
            ISheet hoja = workbook.GetSheetAt(nHoja);
            int resultado = -1;

            for (int rowIndex = 0; rowIndex <= hoja.LastRowNum; rowIndex++)
            {
                IRow fila = hoja.GetRow(rowIndex);
                if (fila != null)
                {
                    ICell celda = fila.GetCell(0);
                    if (celda != null && celda.CellType == CellType.String && celda.StringCellValue.Trim().ToUpper() == "DATE")
                    {
                        return rowIndex; // Retorna la posición del primer "DATE"
                    }
                }
            }

            return resultado;
        }

        public int ObtenerPosicionSegundoDate(IWorkbook workbook, int nHoja)
        {
            ISheet hoja = workbook.GetSheetAt(nHoja);
            int resultado = -1;
            bool primerDateEncontrado = false;

            for (int rowIndex = 0; rowIndex <= hoja.LastRowNum; rowIndex++)
            {
                IRow fila = hoja.GetRow(rowIndex);
                if (fila != null)
                {
                    ICell celda = fila.GetCell(0); // Asumimos que "DATE" está en la primera columna
                    if (celda != null && celda.CellType == CellType.String && celda.StringCellValue.Trim().ToUpper() == "DATE")
                    {
                        if (primerDateEncontrado)
                        {
                            return rowIndex; // Retorna la posición del segundo "DATE"
                        }
                        primerDateEncontrado = true;
                    }
                }
            }
            return resultado;
        }

        public List<int> FilasValidasASK = new List<int>();
        public List<string> ObtenerPlazosValidosASK(IWorkbook workbook, int nHoja)
        {
            List<string> plazosValidos = new List<string>();
            int posicionPrimerDate = ObtenerPosicionPrimerDate(workbook, nHoja);
            int posicionSegundoDate = ObtenerPosicionSegundoDate(workbook, nHoja);

            if (posicionPrimerDate == -1 || posicionSegundoDate == -1)
            {
                MessageBox.Show("No se encontraron las posiciones DATE necesarias.");
                return plazosValidos;
            }

            ISheet hoja = workbook.GetSheetAt(nHoja);
            for (int rowIndex = posicionPrimerDate + 1; rowIndex < posicionSegundoDate; rowIndex++)
            {
                IRow fila = hoja.GetRow(rowIndex);
                if (fila != null)
                {
                    ICell celdaPlazo = fila.GetCell(0);
                    if (celdaPlazo != null && celdaPlazo.CellType == CellType.String)
                    {
                        string plazo = celdaPlazo.StringCellValue.Trim();
                        if (Vindicador2(plazo))
                        {
                            FilasValidasASK.Add(rowIndex);
                            plazosValidos.Add(plazo);
                        }
                    }
                }
            }
            return plazosValidos;
        }

        public List<int> FilasValidasBID = new List<int>();
        public List<string> ObtenerPlazosValidosBID(IWorkbook workbook, int nHoja)
        {
            List<string> plazosValidos = new List<string>();
            int posicionSegundoDate = ObtenerPosicionSegundoDate(workbook, nHoja);

            if (posicionSegundoDate == -1)
            {
                MessageBox.Show("No se encontró la posición del segundo DATE.");
                return plazosValidos;
            }

            ISheet hoja = workbook.GetSheetAt(nHoja);
            for (int rowIndex = posicionSegundoDate + 1; rowIndex <= hoja.LastRowNum; rowIndex++)
            {
                IRow fila = hoja.GetRow(rowIndex);
                if (fila != null)
                {
                    ICell celdaPlazo = fila.GetCell(0);
                    if (celdaPlazo != null && celdaPlazo.CellType == CellType.String)
                    {
                        string plazo = celdaPlazo.StringCellValue.Trim();
                        if (Vindicador2(plazo))
                        {
                            FilasValidasBID.Add(rowIndex);
                            plazosValidos.Add(plazo);
                        }
                    }
                }
            }
            return plazosValidos;
        }

        public List<string> ObtenerListaDefinitivaDePlazos(List<string> plazosAsk, List<string> plazosBid)
        {
            List<string> listaDefinitivaDePlazos = plazosAsk.Intersect(plazosBid).ToList();
            return listaDefinitivaDePlazos;
        }

    }

/////REQUERIMIENTOS 2° PARA BOTON "ESCOGER EXCEL"/////////////////////////////////////////////////////////////////////////////////////////////
    public static class Prompt
    {
        public static string ShowDialog(string caption)
        {
            Form prompt = new Form()
            {
                Width = 350,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label titulo = new Label() { Left = 50, Top = 20, Text = "Seleccione la fecha", Width = 200 };
            
            DateTimePicker datePicker = new DateTimePicker()
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "yyyy-MM-dd",
                Left = 50,
                Top = 50,
                Width = 200
            };

            System.Windows.Forms.Button confirmation = new System.Windows.Forms.Button()
            {
                Text = "Ok",
                Left = 125,
                Width = 100,
                Top = 100,
                DialogResult = DialogResult.OK
            };
            confirmation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(titulo);
            prompt.Controls.Add(datePicker);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                return datePicker.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                return "";
            }
        }
    }

    public class CustomMessageBox : Form
    {
        public CustomMessageBox(string message, string caption)
        {
            this.Text = caption;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(500, 200);

            Label messageLabel = new Label()
            {
                Text = message,
                Left = 10,
                Top = 20,
                Width = 480,
                Height = 100
            };

            System.Windows.Forms.Button minicalendarioButton = new System.Windows.Forms.Button()
            {
                Text = "Minicalendario",
                DialogResult = DialogResult.Yes,
                Left = 30,
                Width = 130,
                Top = 120
            };
            minicalendarioButton.Click += (sender, e) => { this.DialogResult = DialogResult.Yes; this.Close(); };

            System.Windows.Forms.Button archivoButton = new System.Windows.Forms.Button()
            {
                Text = "Archivo",
                DialogResult = DialogResult.No,
                Left = 180,
                Width = 130,
                Top = 120
            };
            archivoButton.Click += (sender, e) => { this.DialogResult = DialogResult.No; this.Close(); };

            System.Windows.Forms.Button cancelButton = new System.Windows.Forms.Button()
            {
                Text = "Cancelar",
                DialogResult = DialogResult.Cancel,
                Left = 330,
                Width = 130,
                Top = 120
            };
            cancelButton.Click += (sender, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.Add(messageLabel);
            this.Controls.Add(minicalendarioButton);
            this.Controls.Add(archivoButton);
            this.Controls.Add(cancelButton);
        }
    }    
}
