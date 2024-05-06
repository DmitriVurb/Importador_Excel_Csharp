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

namespace Prueba_03
{
    public partial class VentanaPrincipal : Form
    {
        public VentanaPrincipal()
        {
            InitializeComponent();

            this.BackgroundImage = Image.FromFile(@"C:\Users\Dmitri\Pictures\Saved Pictures\Roz.jpg");

            this.BackgroundImageLayout = ImageLayout.Stretch;

            ShowRuta.Text = "Todavia se ha seleccionado el archivo";

            DatosExcelCambiados += ActualizarLabelConDatosExcel;
        }

        public delegate void DatosExcelCambiadosDelegate(string[] nuevosDatos);
        public event DatosExcelCambiadosDelegate DatosExcelCambiados;
        
        public void ActualizarLabelConDatosExcel(string[] nuevosDatos)
        {
            if(InvokeRequired)
            {
                Invoke(new Action(() => ActualizarLabelConDatosExcel(nuevosDatos)));
            }
            else
            {
                ShowRuta.Text = nuevosDatos != null && nuevosDatos.Length > 0 ? nuevosDatos[1] : "No hay archivo escogido";
            }
        }

//////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonPreparacion_Click(object sender, EventArgs e)
        {
            RegistrarMultiplesEntitys();
            
            this.Hide();
            FormResultado nuevoForm = new FormResultado();
            nuevoForm.ShowDialog();
            this.Close();
        }

//////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonTruncador_Click(object sender, EventArgs e)
        {
            TruncarTablaConSQL();

            this.Hide();
            FormResultado nuevoForm = new FormResultado();
            nuevoForm.ShowDialog();
            this.Close();
        }

//////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            EscojerExcel();
            SobreescribirMediador();

            Button btn = sender as Button;
            if (btn != null && btn.Text == "Escoger Excel")
            {
                btn.Text = "¿Escoger otro?";
            }
        }

/////////////////BORRAR/////////////////////////////////////////////////////////////////////////////////

        public void EliminarRegistroEspecifico(int idRegistro)
        {
            using (var context = new BD_ImportadorEntities())
            {
                var registro = context.lista_registros.FirstOrDefault(r => r.id == idRegistro);

                if ( registro != null )
                {
                    context.lista_registros.Remove( registro );
                    context.SaveChanges();
                    MessageBox.Show("Registro eliminado con exito");
                }
                else
                {
                    MessageBox.Show("NO");
                }
            }
        }

        public void TruncarTablaConSQL()
        {
            using (var context = new BD_ImportadorEntities())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE lista_registros");
                MessageBox.Show("Tabla truncada con éxito (SQL)");
            }
        }

/////////////////REGISTRAR/////////////////////////////////////////////////////////////////////////////////

        public void RegistrarMultiplesEntitys()
        {
            if (Vindicador1(RutaSeleccionada, FechaSeleccionada))
            {
                MessageBox.Show($"Ruta Válida - Se procede con la Importación de Data: {RutaSeleccionada}");
            }
            else
            {
                MessageBox.Show("Datos Faltantes - Cancelando Proceso");
            }
        }

        public void RegistrarEntity()
        {
            double numeroDouble = 30.567898;
            if (FechaSeleccionada != null)
            {
                var nuevoRegistro = new lista_registros()
                {
                    fecha_registro = DateTime.Parse(FechaSeleccionada),
                    plazo = "5Y",
                    dias_plazo = 30,
                    Nombre_ColumnaC = "MXN",
                    Nombre_ColumnaE = "USD",
                    Demanda_monedaC = numeroDouble,
                    Demanda_monedaE = numeroDouble,
                    Oferta_monedaC = numeroDouble,
                    Oferta_monedaE = numeroDouble
                };
                using (var context = new BD_ImportadorEntities())
                {
                    try
                    {
                        context.lista_registros.Add(nuevoRegistro);
                        context.SaveChanges();

                        MessageBox.Show("Registro agregado con exito a la BD");
                    }
                    catch (DbUpdateException ex)
                    {
                        if (ex.InnerException != null && ex.InnerException.InnerException != null)
                        {
                            MessageBox.Show($"ERROR MAGISTRAL: {ex.InnerException.Message}" + " - " + $"{ex.InnerException.InnerException.Message}");
                        }
                        else
                        {
                            MessageBox.Show($"Ocurrio un error al insertar el registro: {ex.Message}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Data Invalida o Faltante - Cancelando proceso");
            }
        }

/////////////////ESCOGER ARCHIVO/////////////////////////////////////////////////////////////////////////////////

        public void EscojerExcel()
        {
            using (var formFecha = new FormFecha())
            {
                var resultadoDialogo = formFecha.ShowDialog();

                if (resultadoDialogo == DialogResult.OK)
                {
                    string fechaSeleccionada = formFecha.SeleccionadorFecha.Value.ToString("yyyy-MM-dd");
                    MessageBox.Show("Fecha seleccionada en el minicalendario: " + fechaSeleccionada);

                    using (OpenFileDialog abrir = new OpenFileDialog())
                    {
                        abrir.Filter = "Archivos Excel (*.xlsx)|*.xlsx|Hoja de cálculo de Microsoft Excel (.xls)|*.xls";
                        abrir.FilterIndex = 2;

                        if (abrir.ShowDialog() == DialogResult.OK)
                        {
                            string rutaArchivo = abrir.FileName;
                            string nombreArchivo = Path.GetFileNameWithoutExtension(abrir.FileName);

                            var regex = new Regex(@"^prueba_(\d{2})_(\d{2})_(\d{4})$");
                            var match = regex.Match(nombreArchivo);

                            if (match.Success)
                            {
                                string dia = match.Groups[1].Value;
                                string mes = match.Groups[2].Value;
                                string año = match.Groups[3].Value;

                                string fechaArchivo = $"{año}-{mes}-{dia}";

                                MessageBox.Show("Fecha extraida del nombre del archivo: " + fechaArchivo);

                                if (fechaArchivo == fechaSeleccionada)
                                {
                                    datosExcel = new string[] { rutaArchivo, nombreArchivo, fechaArchivo };
                                    MessageBox.Show("Se procede con la carga del archivo");
                                    DatosExcelCambiados?.Invoke(datosExcel);
                                }
                                else
                                {
                                    MessageBox.Show("La fecha seleccionada en el minicalendario no concuerda con la fecha del archivo, se cancela la carga");
                                    datosExcel = null;
                                    DatosExcelCambiados?.Invoke(datosExcel);
                                }                            
                            }
                            else
                            {
                                MessageBox.Show("El archivo NO cumple con el formato de AAAA/MM/DD");
                                datosExcel = null;
                                DatosExcelCambiados?.Invoke(datosExcel);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se escogio ningún archivo, se cancela la carga");
                            datosExcel = null;
                            DatosExcelCambiados?.Invoke(datosExcel);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Se cancela la carga del archivo");
                    datosExcel = null;
                    DatosExcelCambiados?.Invoke(datosExcel);
                }
            }
        }

/////////////////MEDIADOR/////////////////////////////////////////////////////////////////////////////////

        public string LlenadoMediador()
        {
            string ruta = RutaSeleccionada;
            string fecha = FechaSeleccionada;
            List<int> filasCorrectas;
            int hojas = CantidadHojasExcel(ruta);
            StringBuilder llenador = new StringBuilder();

            if (Vindicador1(ruta, fecha))
            {
                llenador.Append(ruta);
                llenador.Append("---");
                llenador.Append(fecha);
                llenador.Append("\n");

                llenador.Append("Cantidad de hojas: " + hojas);
                llenador.Append('\n');

                for (int i = 0; i < hojas; i++)
                {
                    llenador.Append("Hoja N°" + i + "\n");

                    filasCorrectas = FilasValidasExcel(ruta, i);
                    foreach (int fila in filasCorrectas)
                    {
                        llenador.Append("Fila correcta: ");
                        llenador.Append(fila);
                        llenador.Append("\n");
                    }
                }
            }
            else
            {
                llenador.Append("VINDICADOR1 FALLO - PROCESO CANCELADO---------------------------------------------------\n");
                llenador.Append("FECHA Y RUTA NO DEFINIDAS O NO VALIDAS--------------------------------------------------");
                llenador.Append("--------------------------------------------------");
            }

            llenador.Append('\n');
            return llenador.ToString();
        }

        public void SobreescribirMediador()
        {
            //Apunta a la carpeta de ImportadorExcelSQLite\ImportadorBD\ImportadorBD\bin\Debug
            string archivo = AppDomain.CurrentDomain.BaseDirectory;
            //Le da título al .txt y lo crea usando el directorio de "Archivo"
            string rutaArchivo = Path.Combine(archivo, "Mediador.txt");

            string contenido = LlenadoMediador();

            try
            {
                //StreamWriter es una clase, de ahi sale la funcion de File.AppendText, del cual permite ingresar los datos al archivo señalado, WriteLine es el que escribe el "contenido" en el archivo
                using (StreamWriter sw = File.AppendText(rutaArchivo))
                {
                    sw.WriteLine(contenido);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un Error: {ex.Message}");
            }

        }

/////////////////AGRUPAR DATOS EXCEL/////////////////////////////////////////////////////////////////////////////////

        public IWorkbook ObtenerExcel(string archivo)
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

        public int CantidadHojasExcel(string archivo)
        {
            int cantidaHojas = 0;

            IWorkbook workbook = ObtenerExcel(archivo);

            if (workbook != null)
            {
                cantidaHojas = workbook.NumberOfSheets;
            }
            else
            {
                cantidaHojas = 0;
            }
            return cantidaHojas;
        }

        public List<int> FilasValidasExcel(string archivo, int hojaDeterminada)
        {
            var filasValidas = new List<int>();
            IWorkbook workbook = ObtenerExcel(archivo);

            if (workbook != null)
            {
                ISheet hoja = workbook.GetSheetAt(hojaDeterminada);

                int filaInicioDatos = 1;
                bool ubicarDate = false;

                for (int rowIndex = filaInicioDatos; rowIndex <= hoja.LastRowNum; rowIndex++)
                {
                    IRow fila = hoja.GetRow(rowIndex);
                    if (fila != null)
                    {
                        ICell celdaPlazo = fila.GetCell(0);
                        if(celdaPlazo != null && celdaPlazo.CellType == CellType.String)
                        {
                            string valorCeldaPlazo = celdaPlazo.StringCellValue;

                            if (valorCeldaPlazo.Trim().ToUpper() == "DATE")
                            {
                                if (ubicarDate)
                                {
                                    filasValidas.Clear();
                                }
                                ubicarDate = true;
                                continue;
                            }

                            if(Vindicador2(valorCeldaPlazo))
                            {
                                filasValidas.Add(rowIndex);
                            }
                        }
                    }
                }
            }

            return filasValidas;
        }

        public string ObtenerNombreHoja(IWorkbook workbook, int nHoja)
        {
            ISheet hoja = workbook.GetSheetAt(nHoja);

            string resultado = hoja.SheetName;

            return resultado;
        }
        
        public string ObtenerCeldaAsk1(IWorkbook workbook, int nHoja)
        {

        }

        public string ObtenerCeldaAsk2(IWorkbook workbook, int nHoja)
        {

        }

        public string ObtenerCeldaYield1(IWorkbook workbook, int nHoja)
        {

        }

        public string ObtenerCeldaYield2(IWorkbook workbook, int nHoja)
        {

        }



        public string[] datosExcel;


/////////////////VINDICADORES/////////////////////////////////////////////////////////////////////////////////

        //Verifica que exista una ruta y fecha
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

        //Verifica que el plazo sea como debe ser
        public bool Vindicador2(string cadena)
        {
            string patron = @"^\d[YMWD]$";

            Regex regex = new Regex(patron);

            return regex.IsMatch(cadena);
        }

        //Verificar si primera celda es DATE
        public bool Vindicador3()
        {
            bool resultado = true;

            if (Vindicador1(RutaSeleccionada, FechaSeleccionada) == false)
            {
                return resultado;
            }
            else
            {
                IWorkbook workbook = ObtenerExcel(RutaSeleccionada);

                if (workbook == null)
                {
                    return resultado;
                }
                else
                {
                    int hojas = workbook.NumberOfSheets;
                    for (int i = 0; i < hojas; i++)
                    {
                        ISheet hoja = workbook.GetSheetAt(i);
                        IRow fila = hoja.GetRow(0);
                        ICell celda = fila.GetCell(0);
                        string valorCelda = celda.StringCellValue;
                        if (valorCelda.Trim().ToUpper() == "DATE")
                        {
                            resultado = false;
                        }
                    }
                    
                    return resultado;
                }
            }
        }



        public bool Vindicador4()
        {
            bool resultado = false;

            if (Vindicador1(RutaSeleccionada,FechaSeleccionada) == false)
            {
                return resultado;
            }
            else
            {
                IWorkbook workbook = ObtenerExcel(RutaSeleccionada);

                if (workbook == null)
                {
                    return resultado;
                }
                else
                {
                    resultado = true;
                    return resultado;
                }
            }       
        }







/////////////////CAMPO 1 DE 7 - (FECHA)/////////////////////////////////////////////////////////////////////////////////

        public string RutaSeleccionada
        {
            get { return datosExcel != null && datosExcel.Length > 0 ? datosExcel[0] : null; }
        }

        public string FechaSeleccionada
        {
            get { return datosExcel != null && datosExcel.Length > 0 ? datosExcel[2] : null; }
        }

/////////////////CAMPO 2 DE 7 - (PLAZO)/////////////////////////////////////////////////////////////////////////////////

        public string ObtenerPlazoString(int fila, string archivo)
        {
            IWorkbook workbook = ObtenerExcel(archivo);
            if (workbook != null)
            {
                return "Conforme";
            }
            else
            {
                return "RNE";
            }
        }


        public string ObtenerA2(string archivo)
        {
            IWorkbook workbook = ObtenerExcel(archivo);
            if (workbook != null)
            {
                ISheet hoja = workbook.GetSheetAt(0);
                IRow fila = hoja.GetRow(1);
                if (fila != null)
                {
                    ICell celda = fila.GetCell(0);
                    if (celda != null)
                    {
                        return celda.ToString();
                    }
                    else
                    {
                        return "!1";
                    }
                }
                return "!2";
            }
            else
            {
                return "!3";
            }
        }

        

/////////////////CAMPO 3 DE 7 - (DIAS_PLAZO)/////////////////////////////////////////////////////////////////////////////////



/////////////////CAMPO 4 DE 7 - (ASK_COLUMNA C)/////////////////////////////////////////////////////////////////////////////////



/////////////////CAMPO 5 DE 7 - (ASK_COLUMNA E)/////////////////////////////////////////////////////////////////////////////////



/////////////////CAMPO 6 DE 7 - (YIELD_COLUMNA C)/////////////////////////////////////////////////////////////////////////////////



/////////////////CAMPO 7 DE 7 - (YIELD_COLUMNA E)/////////////////////////////////////////////////////////////////////////////////



    }


}

