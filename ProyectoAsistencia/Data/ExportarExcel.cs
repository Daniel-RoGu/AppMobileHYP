using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ClosedXML.Excel;
using System.Threading.Tasks;

namespace ProyectoAsistencia.Data
{
    public class ExportarExcel
    {
        public async Task GenerarExcelDesdeUsuario(string rutaArchivo)
        {
            try
            {
                // 1. Consultar datos desde la tabla Usuario
                DataTable dataTable = ConvertirListaADataTable(await App.Context.GetUsuariosActivos());

                // 2. Crear un archivo Excel con ClosedXML
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Usuarios");

                    // Añadir los encabezados
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dataTable.Columns[i].ColumnName;
                    }

                    // Añadir las filas
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = dataTable.Rows[i][j] is DBNull
                            ? string.Empty
                            : Convert.ToString(dataTable.Rows[i][j]);
                        }
                    }

                    // 3. Guardar el archivo Excel en la ruta especificada
                    workbook.SaveAs(rutaArchivo);
                }

                Console.WriteLine("El archivo Excel se generó correctamente en: " + rutaArchivo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar el archivo Excel: " + ex.Message);
            }
        }

        public static DataTable ConvertirListaADataTable<T>(List<T> lista)
        {
            var dataTable = new DataTable(typeof(T).Name);

            // Obtener todas las propiedades del tipo genérico T
            var propiedades = typeof(T).GetProperties();

            // Crear las columnas en el DataTable
            foreach (var prop in propiedades)
            {
                dataTable.Columns.Add(prop.Name, prop.PropertyType);
            }

            // Agregar las filas al DataTable
            foreach (var item in lista)
            {
                var valores = new object[propiedades.Length];
                for (int i = 0; i < propiedades.Length; i++)
                {
                    valores[i] = propiedades[i].GetValue(item, null);
                }
                dataTable.Rows.Add(valores);
            }

            return dataTable;
        }


    }

}
