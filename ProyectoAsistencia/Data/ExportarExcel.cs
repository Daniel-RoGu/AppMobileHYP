using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ClosedXML.Excel;
using System.Threading.Tasks;
using ProyectoAsistencia.Models;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Essentials;
using System.ComponentModel;
using Xamarin.Forms;
using System.Linq;

//using OfficeOpenXml;

namespace ProyectoAsistencia.Data
{
    public class ExportarExcel
    {

        private List<InformeUsuario> refUsuarioReporte = new List<InformeUsuario>();
        List<ModoEmergencia> mdEmergenciaRef = new List<ModoEmergencia>();
        List<Usuario> userRef = new List<Usuario>();
        List<Hora> horaRef = new List<Hora>();        

        public async void ObjetosConsulta(string tipoObjetoRetorno)
        {
            List<InformeUsuario> infoUsuariosEmergencia = new List<InformeUsuario>();
            List<InformeUsuario> infoUsuariosRutinario = new List<InformeUsuario>();

            try
            {
                mdEmergenciaRef = await App.Context.GetHorariosEmergenciaTodos();
                userRef = await App.Context.GetUsuariosAsync();
                horaRef = await App.Context.GetHorariosTodos();

                if (mdEmergenciaRef != null && tipoObjetoRetorno == "ModoEmergencia")
                {
                    for (int i = 0; i < mdEmergenciaRef.Count; i++)
                    {
                        for (int j = 0; j < userRef.Count; j++)
                        {
                            if (mdEmergenciaRef[i].UsuarioRelacionado == userRef[j].IdentificacionUsuario
                                && mdEmergenciaRef[i].NumeroTarjeteroReporte == userRef[j].NumeroTarjetero)
                            {
                                InformeUsuario infoUsuarioModoEmegencia = new InformeUsuario()
                                {
                                    IdentificacionUsuario = userRef[j].IdentificacionUsuario,
                                    TipoDocumentoUsuario = userRef[j].TipoDocumentoUsuario,
                                    NombreUsuario = userRef[j].NombreUsuario,
                                    GeneroUsuario = userRef[j].GeneroUsuario,
                                    CargoUsuario = userRef[j].CargoUsuario,
                                    CelularUsuario = userRef[j].CelularUsuario,
                                    CorreoUsuario = userRef[j].CorreoUsuario,
                                    EstadoEmpleado = userRef[j].EstadoEmpleado,
                                    EPSEmpleado = userRef[j].EPSEmpleado,
                                    ARLEmpleado = userRef[j].ARLEmpleado,
                                    TipoSangreUsuario = userRef[j].TipoSangreUsuario,
                                    NumeroContactoEmergencia = userRef[j].NumeroContactoEmergencia,
                                    NombreContactoEmergencia = userRef[j].NombreContactoEmergencia,
                                    TipoUsuario = userRef[j].TipoUsuario,
                                    NumeroTarjetero = userRef[j].NumeroTarjetero,
                                    Empresa = userRef[j].Empresa,
                                    Locacion = userRef[j].Locacion,
                                    HoraReporte = mdEmergenciaRef[i].HoraReporte,
                                    EstadoHoraReporte = mdEmergenciaRef[i].EstadoHoraReporte,
                                    AsistenciaRelacionada = mdEmergenciaRef[i].AsistenciaRelacionada,
                                };

                                infoUsuariosEmergencia.Add(infoUsuarioModoEmegencia);
                            }
                        }
                    }
                }

                if (horaRef != null && tipoObjetoRetorno == "ReporteNormal")
                {
                    for (int i = 0; i < horaRef.Count; i++)
                    {
                        for (int j = 0; j < userRef.Count; j++)
                        {
                            if (horaRef[i].UsuarioRelacionado == userRef[j].IdentificacionUsuario)
                            {
                                InformeUsuario infoUsuarioModoEmegencia = new InformeUsuario()
                                {
                                    IdentificacionUsuario = userRef[j].IdentificacionUsuario,
                                    TipoDocumentoUsuario = userRef[j].TipoDocumentoUsuario,
                                    NombreUsuario = userRef[j].NombreUsuario,
                                    GeneroUsuario = userRef[j].GeneroUsuario,
                                    CargoUsuario = userRef[j].CargoUsuario,
                                    CelularUsuario = userRef[j].CelularUsuario,
                                    CorreoUsuario = userRef[j].CorreoUsuario,
                                    EstadoEmpleado = userRef[j].EstadoEmpleado,
                                    EPSEmpleado = userRef[j].EPSEmpleado,
                                    ARLEmpleado = userRef[j].ARLEmpleado,
                                    TipoSangreUsuario = userRef[j].TipoSangreUsuario,
                                    NumeroContactoEmergencia = userRef[j].NumeroContactoEmergencia,
                                    NombreContactoEmergencia = userRef[j].NombreContactoEmergencia,
                                    TipoUsuario = userRef[j].TipoUsuario,
                                    NumeroTarjetero = userRef[j].NumeroTarjetero,
                                    Empresa = userRef[j].Empresa,
                                    Locacion = userRef[j].Locacion,
                                    HoraIngresa = horaRef[i].HoraLlegada,
                                    HoraSalida = horaRef[i].HoraSalida,
                                    EstadoInformeNormal = horaRef[i].EstadoHora,
                                    AsistenciaRelacionada = horaRef[i].AsistenciaRelacionada,
                                };

                                infoUsuariosRutinario.Add(infoUsuarioModoEmegencia);
                            }
                        }
                    }
                }                
                //await Application.Current.MainPage.DisplayAlert("Observacion", $"Numero de registros del modo emergencia: {Convert.ToString(infoUsuariosEmergencia.Count)}", "Aceptar");
                //await Application.Current.MainPage.DisplayAlert("Observacion", $"Numero de registros del modo reporte: {Convert.ToString(infoUsuariosRutinario.Count)}", "Aceptar");
                
                refUsuarioReporte = tipoObjetoRetorno == "ModoEmergencia"
                                   ? infoUsuariosEmergencia
                                   : infoUsuariosRutinario;

                //await Application.Current.MainPage.DisplayAlert("Observacion", $"Registros retornados del excel {Convert.ToString(refUsuarioReporte.Count)}", "Aceptar");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"No se pudo generar los objetos de consulta para el informe: {ex.Message}", "Aceptar");
            }

        }

        public Stream GenerarExcel(List<InformeUsuario> refUsuarioInfoReporte)
        {
            try
            {
                // Definiendo Stream
                var stream = new MemoryStream();

                // Convertir la lista de usuarios a DataTable
                DataTable dataTable = ConvertirListaADataTable(refUsuarioInfoReporte);

                // 2. Crear un archivo Excel con ClosedXML
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Reporte_Asistencia");

                    // Añadir los encabezados
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dataTable.Columns[i].ColumnName;
                    }

                    //Añadir las filas
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = dataTable.Rows[i][j] is DBNull
                            ? string.Empty
                            : Convert.ToString(dataTable.Rows[i][j]);
                        }
                    }

                    // Guardar en un Stream en memoria                    
                    workbook.SaveAs(stream);

                    stream.Position = 0; // Reinicia la posición del Stream                    

                }

                return stream != null
                       ? stream
                       : null;
            }
            catch (Exception ex)
            {                
                Application.Current.MainPage.DisplayAlert("Error", $"No se pudo generar el objeto para el excel: {ex.Message}", "Aceptar");
                return null;
            }
        }


        public static DataTable ConvertirListaADataTable<T>(List<T> lista)
        {
            var dataTable = new DataTable(typeof(T).Name);

            try
            {
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al convertir data table para el archivo Excel: " + ex.Message);
            }

            return dataTable;
        }

        public async void SendEmailWithoutAttachment(string subject, string body, string email)
        {
            try
            {               
                // Crear el mensaje de correo sin archivo adjunto
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = new List<string> { email } // Enviar a los correos de los administradores o a un correo por defecto
                };

                // Enviar el correo
                await Email.ComposeAsync(message);
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error si algo sale mal
                await Application.Current.MainPage.DisplayAlert("Error", $"No se pudo enviar el correo: {ex.Message}", "Aceptar");
            }
        }

        public async void SendEmailWithAttachmentStream(string subject, string body, Stream fileStream, string fileName)
        {
            try
            {
                List<Usuario> UsuariosAdmin = await App.Context.GetUsuariosAdminPrincipalActivos();
                List<string> correos = new List<string>();

                if (UsuariosAdmin != null)
                {
                    for (int i = 0; i < UsuariosAdmin.Count; i++)
                    {
                        correos.Add(UsuariosAdmin[i].CorreoUsuario);
                    }
                }

                // Guardar el Stream como un archivo temporal
                string filePath = SaveStreamToFile(fileStream, fileName);

                if (!File.Exists(filePath))
                {
                    await Application.Current.MainPage.DisplayAlert("Observacion", $"Error: El archivo {filePath} no existe.", "Aceptar");
                    return;
                }

                // Crear el mensaje de correo con el archivo adjunto
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = correos,
                    //To = new List<string> { "danrogu98@gmail.com" }
                };

                // Crear el adjunto usando la ruta del archivo
                var attachment = new EmailAttachment(filePath);
                message.Attachments.Add(attachment);

                if (attachment != null)
                {
                    // Enviar el correo
                    await Email.ComposeAsync(message);
                }
                else
                {
                    // Eliminar el archivo temporal después de enviarlo (opcional)
                    File.Delete(filePath);
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"No se pudo enviar el excel: {ex.Message}", "Aceptar");
            }
        }

        //public async Task SendEmailWithAttachmentStream(string subject, string body, Stream fileStream, string fileName)
        //{
        //    try
        //    {
        //        // Obtener los correos de los administradores activos
        //        List<Usuario> usuariosAdmin = await App.Context.GetUsuariosAdminPrincipalActivos();
        //        List<string> correos = usuariosAdmin?.Select(u => u.CorreoUsuario).ToList() ?? new List<string>();

        //        if (correos.Count == 0)
        //        {
        //            await Application.Current.MainPage.DisplayAlert("Error", "No hay destinatarios disponibles.", "Aceptar");
        //            return;
        //        }

        //        // Guardar el Stream como un archivo temporal
        //        string filePath = SaveStreamToFile(fileStream, fileName);

        //        if (!File.Exists(filePath))
        //        {
        //            await Application.Current.MainPage.DisplayAlert("Error", $"El archivo {filePath} no existe.", "Aceptar");
        //            return;
        //        }

        //        // Crear el mensaje de correo
        //        var message = new EmailMessage
        //        {
        //            Subject = subject,
        //            Body = body,
        //            To = correos
        //        };

        //        // Adjuntar archivo
        //        var attachment = new EmailAttachment(filePath);
        //        message.Attachments.Add(attachment);

        //        // Verificar si el dispositivo soporta envío de correos
        //        if (Email.ComposeAsync(message) != null)
        //        {
        //            await Email.ComposeAsync(message);
        //        }
        //        else
        //        {
        //            await Application.Current.MainPage.DisplayAlert("Error", "El envío de correos no está soportado en este dispositivo.", "Aceptar");
        //        }

        //        // Eliminar archivo temporal después del envío (opcional)
        //        File.Delete(filePath);
        //    }
        //    catch (FeatureNotSupportedException)
        //    {
        //        await Application.Current.MainPage.DisplayAlert("Error", "El envío de correos no está soportado en este dispositivo.", "Aceptar");
        //    }
        //    catch (Exception ex)
        //    {
        //        await Application.Current.MainPage.DisplayAlert("Error", $"No se pudo enviar el correo: {ex.Message}", "Aceptar");
        //    }
        //}

        public async void GenerateAndSendExcel(string tipoObjetoRetorno)
        {
            List<InformeUsuario> infoUsuariosEmergencia = new List<InformeUsuario>();
            List<InformeUsuario> infoUsuariosRutinario = new List<InformeUsuario>();

            try
            {
                mdEmergenciaRef = await App.Context.GetHorariosEmergenciaTodos();
                userRef = await App.Context.GetUsuariosTodosAsync();
                horaRef = await App.Context.GetHorariosTodos();
                                
                //await Application.Current.MainPage.DisplayAlert("Observacion", $"Numero de usuarios: {Convert.ToString(userRef.Count)}", "Aceptar");

                if (mdEmergenciaRef != null && tipoObjetoRetorno == "ModoEmergencia")
                {
                    for (int i = 0; i < mdEmergenciaRef.Count; i++)
                    {
                        for (int j = 0; j < userRef.Count; j++)
                        {
                            if (mdEmergenciaRef[i].UsuarioRelacionado == userRef[j].IdentificacionUsuario
                                && mdEmergenciaRef[i].NumeroTarjeteroReporte == userRef[j].NumeroTarjetero)
                            {
                                InformeUsuario infoUsuarioModoEmegencia = new InformeUsuario()
                                {
                                    IdentificacionUsuario = userRef[j].IdentificacionUsuario,
                                    TipoDocumentoUsuario = userRef[j].TipoDocumentoUsuario,
                                    NombreUsuario = userRef[j].NombreUsuario,
                                    GeneroUsuario = userRef[j].GeneroUsuario,
                                    CargoUsuario = userRef[j].CargoUsuario,
                                    CelularUsuario = userRef[j].CelularUsuario,
                                    CorreoUsuario = userRef[j].CorreoUsuario,
                                    EstadoEmpleado = userRef[j].EstadoEmpleado,
                                    EPSEmpleado = userRef[j].EPSEmpleado,
                                    ARLEmpleado = userRef[j].ARLEmpleado,
                                    TipoSangreUsuario = userRef[j].TipoSangreUsuario,
                                    NumeroContactoEmergencia = userRef[j].NumeroContactoEmergencia,
                                    NombreContactoEmergencia = userRef[j].NombreContactoEmergencia,
                                    TipoUsuario = userRef[j].TipoUsuario,
                                    NumeroTarjetero = userRef[j].NumeroTarjetero,
                                    Empresa = userRef[j].Empresa,
                                    Locacion = userRef[j].Locacion,
                                    HoraReporte = mdEmergenciaRef[i].HoraReporte,
                                    EstadoHoraReporte = mdEmergenciaRef[i].EstadoHoraReporte == "No se presento" ? "Ausente" : mdEmergenciaRef[i].EstadoHoraReporte == "Ausente" ? "Fuera de locacion" : "En locacion",
                                    AsistenciaRelacionada = mdEmergenciaRef[i].AsistenciaRelacionada,
                                };
                                                                
                                if (!infoUsuariosEmergencia.Any(u => u.IdentificacionUsuario == infoUsuarioModoEmegencia.IdentificacionUsuario && u.NombreUsuario == infoUsuarioModoEmegencia.NombreUsuario
                                                                   && u.NumeroTarjetero == infoUsuarioModoEmegencia.NumeroTarjetero && u.HoraReporte == infoUsuarioModoEmegencia.HoraReporte
                                                                   && u.EstadoHoraReporte == infoUsuarioModoEmegencia.EstadoHoraReporte && u.AsistenciaRelacionada == infoUsuarioModoEmegencia.AsistenciaRelacionada
                                                                   )
                                            )
                                {

                                    infoUsuariosEmergencia.Add(infoUsuarioModoEmegencia);
                                }
                            }
                        }
                    }
                }

                if (horaRef != null && tipoObjetoRetorno == "ReporteNormal")
                {
                    for (int i = 0; i < horaRef.Count; i++)
                    {
                        for (int j = 0; j < userRef.Count; j++)
                        {
                            if (horaRef[i].UsuarioRelacionado == userRef[j].IdentificacionUsuario)
                            {
                                InformeUsuario infoUsuarioModoEmegencia = new InformeUsuario()
                                {
                                    IdentificacionUsuario = userRef[j].IdentificacionUsuario,
                                    TipoDocumentoUsuario = userRef[j].TipoDocumentoUsuario,
                                    NombreUsuario = userRef[j].NombreUsuario,
                                    GeneroUsuario = userRef[j].GeneroUsuario,
                                    CargoUsuario = userRef[j].CargoUsuario,
                                    CelularUsuario = userRef[j].CelularUsuario,
                                    CorreoUsuario = userRef[j].CorreoUsuario,
                                    EstadoEmpleado = userRef[j].EstadoEmpleado,
                                    EPSEmpleado = userRef[j].EPSEmpleado,
                                    ARLEmpleado = userRef[j].ARLEmpleado,
                                    TipoSangreUsuario = userRef[j].TipoSangreUsuario,
                                    NumeroContactoEmergencia = userRef[j].NumeroContactoEmergencia,
                                    NombreContactoEmergencia = userRef[j].NombreContactoEmergencia,
                                    TipoUsuario = userRef[j].TipoUsuario,
                                    NumeroTarjetero = userRef[j].NumeroTarjetero,
                                    Empresa = userRef[j].Empresa,
                                    Locacion = userRef[j].Locacion,
                                    HoraIngresa = horaRef[i].HoraLlegada,
                                    HoraSalida = horaRef[i].HoraSalida,
                                    EstadoInformeNormal = horaRef[i].EstadoHora == "Ausente" ? "Fuera de locacion": "En locación",
                                    AsistenciaRelacionada = horaRef[i].AsistenciaRelacionada,
                                };
                                                                
                                if (!infoUsuariosEmergencia.Any(u => u.IdentificacionUsuario == infoUsuarioModoEmegencia.IdentificacionUsuario && u.NombreUsuario == infoUsuarioModoEmegencia.NombreUsuario
                                                                   && u.NumeroTarjetero == infoUsuarioModoEmegencia.NumeroTarjetero && u.HoraReporte == infoUsuarioModoEmegencia.HoraReporte
                                                                   && u.EstadoHoraReporte == infoUsuarioModoEmegencia.EstadoHoraReporte && u.AsistenciaRelacionada == infoUsuarioModoEmegencia.AsistenciaRelacionada
                                                                   )
                                            )
                                {

                                    infoUsuariosRutinario.Add(infoUsuarioModoEmegencia);
                                }

                            }
                        }
                    }
                }                

                refUsuarioReporte = tipoObjetoRetorno == "ModoEmergencia"
                                   ? infoUsuariosEmergencia
                                   : infoUsuariosRutinario;
                
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"No se pudo generar los objetos de consulta para el informe: {ex.Message}", "Aceptar");
            }
                        
            var excelStream2 = GenerarExcel(refUsuarioReporte);

            //Enviar el correo con el adjunto
            if (excelStream2 != null)
            {
                //await Application.Current.MainPage.DisplayAlert("Exito", "Se genero excelStream2", "Aceptar");
                SendEmailWithAttachmentStream("Reporte Excel", "Por favor, revisa el archivo adjunto.", excelStream2, $"Reporte{tipoObjetoRetorno}.xlsx");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Exito", "No se genero excelStream2", "Aceptar");
            }

        }

        public string SaveStreamToFile(Stream fileStream, string fileName)
        {
            try
            {
                // Crear una ruta temporal en el dispositivo
                //string tempFilePath = Path.Combine(Path.GetTempPath(), fileName);
                string tempFilePath = Path.Combine(FileSystem.CacheDirectory, fileName);


                // Guardar el Stream como un archivo
                using (var file = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                {
                    fileStream.CopyTo(file);
                }

                return tempFilePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el archivo: {ex.Message}");
                return null;
            }
        }


    }

}

