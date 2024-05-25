using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace u5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Agregar columnas al DataGridView
            dataGridView1.Columns.Add("NombreArchivo", "Nombre");
            dataGridView1.Columns.Add("TamanoArchivo", "Tamaño");
            dataGridView1.Columns.Add("FechaModificacion", "Fecha de Modificación");
            dataGridView1.Columns.Add("TipoArchivo", "Tipo");

            // Configurar la propiedad AutoSizeColumnsMode del DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            string rutaCarpeta = txtRutaCarpeta.Text;

            if (Directory.Exists(rutaCarpeta))
            {
                DirectoryInfo directorio = new DirectoryInfo(rutaCarpeta);

                // Limpiar DataGridView antes de mostrar nuevos resultados
                dataGridView1.Rows.Clear();

                // Diccionarios para estadísticas
                Dictionary<string, int> tipoArchivoConteo = new Dictionary<string, int>();
                Dictionary<string, long> tipoArchivoTamano = new Dictionary<string, long>();
                HashSet<string> archivosDuplicados = new HashSet<string>();

                // Obtener archivos y subcarpetas
                FileInfo[] archivos = directorio.GetFiles("*", SearchOption.AllDirectories);

                // Calcular el tamaño total de la carpeta
                long tamanoTotal = CalcularTamanoCarpeta(directorio);

                // Mostrar el tamaño total en MB o GB, dependiendo de su magnitud
                lblTamanoTotal.Text = FormatearTamano(tamanoTotal);

                // Análisis de archivos
                foreach (var archivo in archivos)
                {
                    string extension = archivo.Extension.ToLower();
                    string nombreConTamano = archivo.Name + archivo.Length;

                    // Contar tipos de archivos
                    if (tipoArchivoConteo.ContainsKey(extension))
                    {
                        tipoArchivoConteo[extension]++;
                        tipoArchivoTamano[extension] += archivo.Length;
                    }
                    else
                    {
                        tipoArchivoConteo[extension] = 1;
                        tipoArchivoTamano[extension] = archivo.Length;
                    }

                    // Detectar archivos duplicados
                    if (archivosDuplicados.Contains(nombreConTamano))
                    {
                        // Marcar como duplicado
                        dataGridView1.Rows.Add(archivo.Name, FormatearTamano(archivo.Length), archivo.LastWriteTime, extension + " (Duplicado)");
                    }
                    else
                    {
                        archivosDuplicados.Add(nombreConTamano);
                        dataGridView1.Rows.Add(archivo.Name, FormatearTamano(archivo.Length), archivo.LastWriteTime, extension);
                    }
                }

                // Mostrar estadísticas
                MostrarEstadisticas(tipoArchivoConteo, tipoArchivoTamano);
            }
            else
            {
                MessageBox.Show("La ruta especificada no es válida.");
            }
        }

        // Método para calcular el tamaño total de la carpeta y sus subcarpetas
        private long CalcularTamanoCarpeta(DirectoryInfo carpeta)
        {
            long tamanoTotal = 0;

            // Calcular el tamaño de los archivos en la carpeta actual
            foreach (var archivo in carpeta.GetFiles())
            {
                tamanoTotal += archivo.Length;
            }

            // Calcular el tamaño de las subcarpetas de manera recursiva
            foreach (var subCarpeta in carpeta.GetDirectories())
            {
                tamanoTotal += CalcularTamanoCarpeta(subCarpeta);
            }

            return tamanoTotal;
        }

        // Método para formatear el tamaño en bytes a MB o GB, según su magnitud
        private string FormatearTamano(long bytes)
        {
            const long kilobyte = 1024;
            const long megabyte = kilobyte * 1024;
            const long gigabyte = megabyte * 1024;

            if (bytes >= gigabyte)
            {
                return $"{(double)bytes / gigabyte:0.##} GB";
            }
            else if (bytes >= megabyte)
            {
                return $"{(double)bytes / megabyte:0.##} MB";
            }
            else if (bytes >= kilobyte)
            {
                return $"{(double)bytes / kilobyte:0.##} KB";
            }
            else
            {
                return $"{bytes} bytes";
            }
        }

        // Método para mostrar estadísticas en un MessageBox o en un control adicional
        private void MostrarEstadisticas(Dictionary<string, int> tipoArchivoConteo, Dictionary<string, long> tipoArchivoTamano)
        {
            string estadisticas = "Estadísticas de tipos de archivos:\n\n";

            foreach (var tipo in tipoArchivoConteo.Keys)
            {
                estadisticas += $"{tipo}: {tipoArchivoConteo[tipo]} archivos, {FormatearTamano(tipoArchivoTamano[tipo])} en total\n";
            }

            MessageBox.Show(estadisticas, "Estadísticas de archivos");
        }

        // Métodos adicionales para manejar diferentes tipos de organización de archivos

        // Leer un archivo secuencial línea por línea
        private void LeerArchivoSecuencial(string rutaArchivo)
        {
            if (File.Exists(rutaArchivo))
            {
                using (StreamReader sr = new StreamReader(rutaArchivo))
                {
                    string contenido = sr.ReadToEnd();
                    MessageBox.Show("Contenido del archivo:\n" + contenido);
                }
            }
            else
            {
                MessageBox.Show("El archivo especificado no existe.");
            }
        }
        // Método para crear un índice secuencial y mostrar el contenido del archivo
        private void CrearIndiceSecuencial(string rutaArchivo)
        {
            if (File.Exists(rutaArchivo))
            {
                using (StreamReader sr = new StreamReader(rutaArchivo))
                {
                    string linea;
                    int numeroLinea = 1;
                    StringBuilder contenido = new StringBuilder();
                    while ((linea = sr.ReadLine()) != null)
                    {
                        contenido.AppendLine($"Línea {numeroLinea}: {linea}");
                        numeroLinea++;
                    }
                    MessageBox.Show(contenido.ToString(), "Contenido del archivo");
                }
            }
            else
            {
                MessageBox.Show("El archivo especificado no existe.");
            }
        }

        // Método para leer una línea específica del archivo
        private void LeerLineaEspecifica(string rutaArchivo)
        {
            if (File.Exists(rutaArchivo))
            {
                string numeroLineaStr = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el número de línea a leer:", "Lectura de línea", "1");
                if (int.TryParse(numeroLineaStr, out int numeroLinea))
                {
                    using (StreamReader sr = new StreamReader(rutaArchivo))
                    {
                        string linea;
                        int contadorLinea = 1;
                        while ((linea = sr.ReadLine()) != null)
                        {
                            if (contadorLinea == numeroLinea)
                            {
                                MessageBox.Show($"Contenido de la línea {numeroLinea}: {linea}", "Línea específica");
                                return;
                            }
                            contadorLinea++;
                        }
                        MessageBox.Show($"El archivo no tiene {numeroLinea} líneas.", "Línea no encontrada");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un número válido.", "Error de entrada");
                }
            }
            else
            {
                MessageBox.Show("El archivo especificado no existe.");
            }
        }

        // Crear un índice simple para un archivo secuencial indexado
        private Dictionary<int, long> CrearIndiceArchivo(string rutaArchivo)
        {
            var indice = new Dictionary<int, long>();
            if (File.Exists(rutaArchivo))
            {
                using (StreamReader sr = new StreamReader(rutaArchivo))
                {
                    long posicion = 0;
                    int numeroLinea = 0;
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        indice[numeroLinea] = posicion;
                        posicion = sr.BaseStream.Position;
                        numeroLinea++;
                    }
                }
            }
            else
            {
                MessageBox.Show("El archivo especificado no existe.");
            }
            return indice;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            string rutaArchivo = txtRutaArchivo.Text;
            LeerArchivoSecuencial(rutaArchivo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string rutaArchivo = txtRutaArchivo.Text;
            CrearIndiceSecuencial(rutaArchivo);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string rutaArchivo = txtRutaArchivo.Text;
            LeerLineaEspecifica(rutaArchivo);
        }
    }
}

