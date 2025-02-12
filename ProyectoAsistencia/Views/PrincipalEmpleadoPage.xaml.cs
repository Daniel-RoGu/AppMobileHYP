using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoAsistencia.ViewModels;
using ProyectoAsistencia.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Renci.SshNet.Messages;

namespace ProyectoAsistencia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrincipalEmpleadoPage : ContentPage
    {

        string estadoHora = "0";
        bool modoEmergencia = false;
        List<string> registroEstadoHorario = new List<string>();
        List<Tarjetero> tarjeteroRef = new List<Tarjetero>();
        List<Usuario> userRef = new List<Usuario>();
        List<ModoEmergencia> mdEmergenciaRef = new List<ModoEmergencia>();
        List<string> registroTarjetasSelect = new List<string>();
        private string fechaActual = "";
        private string horaActual = "";

        public PrincipalEmpleadoPage()
        {
            InitializeComponent();
            OnAppearing();
            this.BindingContext = new PrincipalEmpleadoViewModel();
            //LoadItems();            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //estadoHora = "0";
            CargarEmpresas();
            CargarLocaciones();
            CargarNumerosTarjetero();
        }

        //private void LoadItems()
        //{
        //    EmpleadoEntry.Text = "Empleado";
        //    tipoEmpresaPicker.SelectedIndex = -1;
        //    tipoLocacionPicker.SelectedIndex = -1;
        //}

        private void OnFrameTapped(object sender, EventArgs e)
        {
            // Tu lógica aquí
            DisplayAlert("Frame Tapped", "¡Has hecho clic en el Frame!", "OK");
        }

        private void OnAlarmaClicked(object sender, EventArgs e)
        {
            modoEmergencia = true;
            FechaActual();

            try
            {
                if (modoEmergencia == true)
                {
                    botonRef.BackgroundColor = Color.DarkGoldenrod;
                    botonRef.Text = "Finalizar";

                    EmergencyModo.IsEnabled = false;
                    AdminModo.IsEnabled = false;

                    // Crear el ToolbarItem
                    ToolbarItem InfoemergencyItem = new ToolbarItem
                    {
                        Text = "informe",
                        IconImageSource = "informe.png",
                        Order = ToolbarItemOrder.Primary,
                        Priority = 1,
                        Command = new Command(GenerarInformeEmergencia)
                    };

                    // Agregarlo inicialmente si es necesario
                    ToolbarItems.Add(InfoemergencyItem);

                    // Crear el ToolbarItem
                    ToolbarItem HomeItem = new ToolbarItem
                    {
                        Text = "Home",
                        IconImageSource = "home.png",
                        Order = ToolbarItemOrder.Primary,
                        Priority = 1,
                        Command = new Command(OnHomeClicked)
                    };

                    // Agregarlo inicialmente si es necesario
                    ToolbarItems.Add(HomeItem);
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error en las Empresas", $"Ocurrió un problema al cargar los datos: {ex.Message}", "OK");
            }

            CargarNumerosTarjetero();
        }

        private async void OnAdministracionClicked(object sender, EventArgs e)
        {
            // Redirige a la página 'SecondPage'
            if (mdEmergenciaRef.Count < 0)
            {
                mdEmergenciaRef = await App.Context.GetHorariosEmergenciaTodos();
                userRef = await App.Context.GetUsuariosActivos();
            }

            await Navigation.PushAsync(new LoginPage());
        }

        private async void OnHomeClicked()
        {            
            await Navigation.PushAsync(new PrincipalEmpleadoPage());
        }

        private async void CargarEmpresas()
        {
            try
            {
                // Consulta SQL: Obtén los datos con el modelo de la base de datos
                var datosConsulta = await App.Context.GetEmpresasActivas();

                // Usamos LINQ para proyectar solo la propiedad NombreEmpresa
                var listaEmpresas = datosConsulta.Select(d => d.NombreEmpresa).ToList();

                // Ahora, listaTipoDocumento contiene solo los valores de NombreEmpresa


                // Enlaza los datos al Picker
                tipoEmpresaPicker.ItemsSource = listaEmpresas;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error en las Empresas", $"Ocurrió un problema al cargar los datos: {ex.Message}", "OK");
            }
        }

        private async void CargarLocaciones()
        {
            try
            {
                // Consulta SQL: Obtén los datos con el modelo de la base de datos
                var datosConsulta = await App.Context.GetLocacionesActivas();

                // Usamos LINQ para proyectar solo la propiedad NombreLocacion
                var listaLocaciones = datosConsulta.Select(d => d.NombreLocacion).ToList();

                // Ahora, listaTipoDocumento contiene solo los valores de NombreLocacion


                // Enlaza los datos al Picker
                tipoLocacionPicker.ItemsSource = listaLocaciones;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error en las Locaciones", $"Ocurrió un problema al cargar los datos: {ex.Message}", "OK");
            }
        }

        private async void CargarNumerosTarjetero()
        {
            try
            {
                // Se obtienen los datos seleccionados por el usuario en la vista
                string empresaSelect = tipoEmpresaPicker.SelectedItem?.ToString() ?? string.Empty;
                string locacionSelect = tipoLocacionPicker.SelectedItem?.ToString() ?? string.Empty;
                string empleadoSearch = EmpleadoEntry.Text;

                // Se actualiza el titulo del tarjetero con el nombre de la empresa seleccionada
                if (!string.IsNullOrEmpty(empresaSelect) && empresaSelect != "-1" && empresaSelect != "")
                {
                    LabelTarjetero.Text = empresaSelect;
                }

                // Se Obtienen los datos del tarjetero
                var datosConsulta = !string.IsNullOrEmpty(empresaSelect) && empresaSelect != "-1" && empresaSelect != ""
                                    ? await App.Context.GetNumerosTarjeteroNoDisponiblesXEmpresaAsync(empresaSelect)
                                    : !string.IsNullOrEmpty(locacionSelect) && locacionSelect != "-1" && locacionSelect != ""
                                    ? await App.Context.GetNumerosTarjeteroNoDisponiblesXEmpresaLocacionAsync(empresaSelect, locacionSelect)
                                    //: !string.IsNullOrEmpty(empleadoSearch) && empleadoSearch != ""
                                    //? await App.Context.GetUsuarioBuscadoIndividual(empleadoSearch)
                                    : await App.Context.GetNumerosTarjeteroNoDisponiblesAsync();

                //var datosUsuario = await App.Context.GetUsuariosActivos();

                tarjeteroRef = datosConsulta;

                // Extraer la lista de números
                var listaNumeros = datosConsulta.Select(d => d.NumeroEnTarjetero).ToList();

                // Limpiar el grid existente
                gridTarjetero.Children.Clear();
                gridTarjetero.RowDefinitions.Clear();
                gridTarjetero.ColumnDefinitions.Clear();

                // Configurar dimensiones del grid
                const int columnas = 15; // Número fijo de columnas
                int totalItems = listaNumeros.Count;
                int filas = (int)Math.Ceiling((double)totalItems / columnas);

                // Agregar las definiciones de fila
                for (int i = 0; i < filas; i++)
                {
                    gridTarjetero.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                }

                // Agregar las definiciones de columna
                for (int i = 0; i < columnas; i++)
                {
                    gridTarjetero.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                }

                // Agregar los botones dinámicamente al grid
                for (int i = 0; i < totalItems; i++)
                {
                    int fila = i / columnas;
                    int columna = i % columnas;
                    Color color = Color.White;

                    //GestionColorBoton(Convert.ToString(listaNumeros[i]));

                    var user = await App.Context.GetUsuarioIndividual(Convert.ToString(listaNumeros[i]));
                    //Console.WriteLine(user);
                    var horas = await App.Context.GetUltimoHorariosUsuario(user.IdentificacionUsuario);
                    //Console.WriteLine(horas);

                    if (horas != null)
                    {
                        estadoHora = horas.EstadoHora;
                    }
                    else
                    {
                        estadoHora = "0";
                    }

                    if (estadoHora == "0" || estadoHora == "Ausente")
                    {
                        color = Color.Red;
                    }
                    else
                    {
                        color = Color.Green;
                    }

                    var boton = new Button
                    {
                        Text = listaNumeros[i].ToString(),
                        WidthRequest = 60,
                        HeightRequest = 50,
                        BackgroundColor = color,
                        TextColor = Color.FromHex("#004F73"),
                    };

                    // Asignar el evento Clicked al botón
                    boton.Clicked += BotonHabilitarAsistencia_Clicked;

                    gridTarjetero.Children.Add(boton, columna, fila);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error en el Tarjetero", $"Ocurrió un problema al cargar los datos: {ex.Message}", "OK");
            }
        }

        //private Button botonSeleccionado;  // Variable global para almacenar el último botón seleccionado

        // Método asociado al evento Clicked
        private async void BotonHabilitarAsistencia_Clicked(object sender, EventArgs e)
        {
            var botonActual = sender as Button;
            // Cambiar el color del botón previamente seleccionado, si existe
            if (modoEmergencia == true)
            {
                if (botonActual != null)
                {
                    botonActual.BackgroundColor = Color.LightSkyBlue;

                    FechaActual();
                    var user = await App.Context.GetUsuarioIndividual(botonActual.Text);

                    // Hay que actualizar el estado actual de los tarjeteros del modo emergencia
                    try
                    {
                        registroTarjetasSelect.Add(botonActual.Text);

                        ModoEmergencia registro = new ModoEmergencia()
                        {
                            HoraReporte = horaActual,
                            EstadoHoraReporte = "Presente",
                            AsistenciaRelacionada = fechaActual,
                            UsuarioRelacionado = user.IdentificacionUsuario,
                            NumeroTarjeteroReporte = botonActual.Text,
                        };

                        await App.Context.InsertHoraModoEmergencia(registro);

                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Error en Modo Emergencia", $"Ocurrió un problema al cargar los datos: {ex.Message}", "OK");
                    }

                }
            }

        }

        private void OnTipoUsuarioPickerChanged(object sender, EventArgs e)
        {
            CargarNumerosTarjetero();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var registrosActuales = await App.Context.GetHorariosEmergenciaTodos();
            
            if (modoEmergencia != true)
            {
                if (!string.IsNullOrEmpty(EmpleadoEntry.Text))
                {
                    string referencia = EmpleadoEntry.Text;

                    EmpleadoEntry.Text = string.Empty;
                    tipoEmpresaPicker.SelectedIndex = -1;
                    tipoLocacionPicker.SelectedIndex = -1;

                    // Acción cuando el botón es presionado
                    await Navigation.PushAsync(new ControlAsistenciaPage(referencia));
                }
            }
            else
            {
                //await Application.Current.MainPage.DisplayAlert("Numero de registros de tarjetero", Convert.ToString(tarjeteroRef.Count), "OK");
                //await Application.Current.MainPage.DisplayAlert("Numero de registros en tabla emergencia", Convert.ToString(registrosActuales.Count), "OK");

                for (int i = 0; i < tarjeteroRef.Count; i++)
                {
                    try
                    {
                        var user = await App.Context.GetUsuarioIndividual(Convert.ToString(tarjeteroRef[i].NumeroEnTarjetero));
                        userRef.Add(user); // Lista para guardar los registros de usario que se van a usar en el informe de emergencia
                        var horas = await App.Context.GetUltimoHorariosUsuario(user.IdentificacionUsuario);

                        if (horas != null)
                        {
                            if (registroTarjetasSelect.Count > 0)
                            {
                                for (int j = 0; j < registroTarjetasSelect.Count; j++)
                                {

                                    string numRefTarjetero = Convert.ToString(tarjeteroRef[i].NumeroEnTarjetero);
                                    //string nomRefRegistrosAsalvo = registroTarjetasSelect[j];    

                                    if (!registroTarjetasSelect.Contains(numRefTarjetero) && registrosActuales[registrosActuales.Count - 1].NumeroTarjeteroReporte != numRefTarjetero)
                                    {                                       
                                        ModoEmergencia registro = new ModoEmergencia()
                                        {
                                            HoraReporte = horaActual,
                                            EstadoHoraReporte = horas.EstadoHora != null && horas.EstadoHora != "Ausente" ? "No se presento" : "Ausente",
                                            AsistenciaRelacionada = fechaActual,
                                            UsuarioRelacionado = user.IdentificacionUsuario,
                                            NumeroTarjeteroReporte = numRefTarjetero,
                                        };

                                        await App.Context.InsertHoraModoEmergencia(registro);
                                        //registrosActuales = await App.Context.GetHorariosEmergenciaTodos();
                                    }
                                }
                            }
                            else
                            {
                                //await Application.Current.MainPage.DisplayAlert("Estado ultimo horario normal registrado", Convert.ToString(horas.EstadoHora), "OK");

                                ModoEmergencia registro = new ModoEmergencia()
                                {
                                    HoraReporte = horaActual,
                                    EstadoHoraReporte = horas.EstadoHora != null && horas.EstadoHora != "Ausente" ? "No se presento" : "Ausente",
                                    AsistenciaRelacionada = fechaActual,
                                    UsuarioRelacionado = user.IdentificacionUsuario,
                                    NumeroTarjeteroReporte = Convert.ToString(tarjeteroRef[i].NumeroEnTarjetero),
                                };


                                await App.Context.InsertHoraModoEmergencia(registro);
                            }
                        }
                        else
                        {
                            var mdEmergenciaRef = await App.Context.GetUltimoHorarioModoEmergencia(userRef[i].IdentificacionUsuario);
                            bool limitadorHora = (TimeSpan.Parse(horaActual).Add((TimeSpan.FromSeconds(-10))) < TimeSpan.Parse(mdEmergenciaRef.HoraReporte));
                            string estadoRef = "";                           

                            if (mdEmergenciaRef != null && horas == null)
                            {
                                if (limitadorHora)
                                {
                                    estadoRef = mdEmergenciaRef.EstadoHoraReporte != null && mdEmergenciaRef.EstadoHoraReporte != "No se presento" ? "A salvo" : "No se presento";
                                }
                                else
                                {
                                    estadoRef = "No se presento";
                                }

                                ModoEmergencia registro = new ModoEmergencia()
                                {
                                    HoraReporte = horaActual,
                                    EstadoHoraReporte = estadoRef,
                                    AsistenciaRelacionada = fechaActual,
                                    UsuarioRelacionado = user.IdentificacionUsuario,
                                    NumeroTarjeteroReporte = Convert.ToString(tarjeteroRef[i].NumeroEnTarjetero),
                                };


                                await App.Context.InsertHoraModoEmergencia(registro);                                
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Error en Modo Emergencia", $"Ocurrió un problema al cargar los datos: {ex.Message}", "OK");
                    }
                }

                registrosActuales = await App.Context.GetHorariosEmergenciaTodos();
                modoEmergencia = false;

                if (modoEmergencia == false)
                {
                    botonRef.BackgroundColor = Color.FromHex("#3A84B2");
                    botonRef.Text = "&#xE80F;";
                    EmergencyModo.IsEnabled = true;
                    AdminModo.IsEnabled = true;
                }

                //Console.WriteLine(registrosActuales);
                //mdEmergenciaRef = registrosActuales; // Lista para guardar los elementos del modo emergencia que se van a usar en el informe
                await Navigation.PushAsync(new PrincipalEmpleadoPage());
            }

        }

        public async void GestionColorBoton(string idref)
        {
            try
            {
                if (!string.IsNullOrEmpty(idref))
                {
                    var user = await App.Context.GetUsuarioIndividual(idref);
                    Console.WriteLine(user);
                    //var horas = await App.Context.GetHorariosUsuario(user.IdentificacionUsuario);
                    var horas = await App.Context.GetUltimoHorariosUsuario(user.IdentificacionUsuario);
                    Console.WriteLine(horas);

                    if (horas != null)
                    {
                        //estadoHora = horas[0].EstadoHora;
                        //estadoHora = horas.LastOrDefault().EstadoHora;
                        estadoHora = horas.EstadoHora;
                    }
                    else
                    {
                        estadoHora = "0";
                    }

                    registroEstadoHorario.Add(estadoHora);
                }
                else
                {
                    await DisplayAlert("Error", $"Sin usuario de referencia", "OK");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error color botones", $"Ocurrió un problema al cargar los datos: {ex.Message}", "OK");
            }

            //var horarios = await App.Context.GetHorariosTodos();
            //Console.WriteLine(registroEstadoHorario);

        }

        public void FechaActual()
        {
            TimeZoneInfo zonaHorariaColombia;

            try
            {
                // Intentar con el identificador de Windows
                zonaHorariaColombia = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            }
            catch (TimeZoneNotFoundException)
            {
                try
                {
                    // Intentar con el identificador de IANA (para Linux/macOS)
                    zonaHorariaColombia = TimeZoneInfo.FindSystemTimeZoneById("America/Bogota");
                }
                catch (TimeZoneNotFoundException)
                {
                    // Si falla, usar UTC como fallback
                    Console.WriteLine("No se pudo encontrar la zona horaria de Colombia. Usando UTC.");
                    zonaHorariaColombia = TimeZoneInfo.Utc;
                }
            }

            // Hora UTC actual
            DateTime utcNow = DateTime.UtcNow;

            // Convertir a hora de Colombia
            DateTime horaColombia = TimeZoneInfo.ConvertTimeFromUtc(utcNow, zonaHorariaColombia);

            // Mostrar la fecha actual
            fechaActual = horaColombia.ToString("dd/MM/yyyy");

            // Obtener solo la hora (ejemplo: "14:35:00")
            horaActual = horaColombia.ToString("HH:mm:ss");
        }

        public async void GenerarInformeEmergencia()
        {
            List<string> noReportados = new List<string>();           

            try
            {                
                userRef = await App.Context.GetUsuariosTodosAsync();
                //var horas = await App.Context.GetHorariosTodos();                
                List<usuarioEmergencia> usuariosEmergencia = new List<usuarioEmergencia>();


                for (int i = 0; i < userRef.Count; i++)
                {
                    var mdEmergenciaRef = await App.Context.GetUltimoHorarioModoEmergencia(userRef[i].IdentificacionUsuario);
                                        
                    bool esMdEmergenciaRef = ( (mdEmergenciaRef != null && (TimeSpan.Parse(horaActual).Add((TimeSpan.FromSeconds(-10))) < TimeSpan.Parse(mdEmergenciaRef.HoraReporte)) ) &&
                                               (mdEmergenciaRef.AsistenciaRelacionada == fechaActual
                                               && mdEmergenciaRef.UsuarioRelacionado == userRef[i].IdentificacionUsuario
                                               && (mdEmergenciaRef.EstadoHoraReporte == "A salvo"))
                                             );

                    var hora = await App.Context.GetUltimoHorariosUsuario(userRef[i].IdentificacionUsuario);

                    bool esHora = hora != null;

                    bool esHoraRef = ((hora != null) &&
                                      (hora.UsuarioRelacionado == userRef[i].IdentificacionUsuario
                                      && hora.AsistenciaRelacionada == fechaActual
                                      && hora.EstadoHora == "Presente")
                                     );                    

                    if (hora != null && mdEmergenciaRef != null && userRef != null)
                    {                        

                        if ((esMdEmergenciaRef == false && esHoraRef) || (esMdEmergenciaRef == false
                                                                          && hora.AsistenciaRelacionada != fechaActual
                                                                          && hora.EstadoHora == "Presente")
                           )
                        {
                            if (usuariosEmergencia != null)
                            {
                                if (!usuariosEmergencia.Any(u => u.nombre == userRef[i].NombreUsuario && u.numero == userRef[i].NumeroTarjetero))
                                {
                                    usuariosEmergencia.Add(new usuarioEmergencia
                                    {
                                        nombre = userRef[i].NombreUsuario,
                                        numero = userRef[i].NumeroTarjetero
                                    });
                                }
                            }
                            else
                            {
                                usuariosEmergencia.Add(new usuarioEmergencia
                                {
                                    nombre = userRef[i].NombreUsuario,
                                    numero = userRef[i].NumeroTarjetero
                                });
                            }
                        }                       
                    }
                    else if (mdEmergenciaRef.UsuarioRelacionado != userRef[i].IdentificacionUsuario && !esHora)
                    {
                        if (usuariosEmergencia != null)
                        {
                            if (!usuariosEmergencia.Any(u => u.nombre == userRef[i].NombreUsuario && u.numero == userRef[i].NumeroTarjetero))
                            {
                                usuariosEmergencia.Add(new usuarioEmergencia
                                {
                                    nombre = userRef[i].NombreUsuario,
                                    numero = userRef[i].NumeroTarjetero
                                });
                            }
                        }
                        else
                        {
                            usuariosEmergencia.Add(new usuarioEmergencia
                            {
                                nombre = userRef[i].NombreUsuario,
                                numero = userRef[i].NumeroTarjetero
                            });
                        }
                    }

                }

                //await Application.Current.MainPage.DisplayAlert("Usuarios que no se reportaron", Convert.ToString(usuariosEmergencia.Count), "OK");

                if (usuariosEmergencia != null && usuariosEmergencia.Count > 0)
                {
                    foreach (var usuario in usuariosEmergencia)
                    {
                        noReportados.Add($"🔹 Usuario: {usuario.nombre} con numero de tarjetero: {usuario.numero}");
                    }
                }

                //Console.WriteLine(noReportados);

                await DisplayAlert(
                    "📋 Reporte de usuarios Modo Emergencia",
                     $"{string.Join("\n", noReportados)}",
                     "OK"
                );

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error en Generar Informe", $"Ocurrió un problema al cargar los datos: {ex.Message}", "OK");
            }

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            tipoEmpresaPicker.SelectedIndex = -1;
            tipoLocacionPicker.SelectedIndex = -1;

            CargarNumerosTarjetero();
        }
    }

    public class usuarioEmergencia
    {
        public string nombre {  get; set; }
        public string numero { get; set; }
    }

}