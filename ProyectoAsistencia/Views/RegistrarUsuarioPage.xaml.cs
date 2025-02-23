using ProyectoAsistencia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using Button = Xamarin.Forms.Button;

namespace ProyectoAsistencia.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrarUsuarioPage : ContentPage
	{
		public RegistrarUsuarioPage ()
		{
			InitializeComponent ();
		}

        // Método para cargar datos en el Picker
        private async void CargarTiposIdentificacion()
        {
            try
            {
                // Consulta SQL: Obtén los datos con el modelo de la base de datos
                var datosConsulta = await App.Context.GetTipoDocumentoAsync();

                // Usamos LINQ para proyectar solo la propiedad _tipoDocumento
                var listaTipoDocumento = datosConsulta.Select(d => d._tipoDocumento).ToList();

                // Ahora, listaTipoDocumento contiene solo los valores de _tipoDocumento


                // Enlaza los datos al Picker
                tipoIdentificacionPicker.ItemsSource = listaTipoDocumento;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un problema al cargar los datos: {ex.Message}", "OK");
            }
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
                await DisplayAlert("Error", $"Ocurrió un problema al cargar los datos: {ex.Message}", "OK");
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
                await DisplayAlert("Error", $"Ocurrió un problema al cargar los datos: {ex.Message}", "OK");
            }
        }

        //private async void CargarNumerosTarjetero(string tipoUsuario)
        //{
        //    try
        //    {
        //        // Consulta SQL: Obtén los datos con el modelo de la base de datos
        //        var datosConsulta = await App.Context.GetNumerosTarjeteroDisponiblesAsync();

        //        if (tipoUsuario == "Empleado")
        //        {
        //            // Consulta SQL: Obtén los datos con el modelo de la base de datos
        //            datosConsulta = await App.Context.GetNumerosTarjeteroEmpleadosAsync();
        //        }
        //        else if (tipoUsuario == "Visitante")                 
        //        {
        //            // Consulta SQL: Obtén los datos con el modelo de la base de datos
        //            datosConsulta = await App.Context.GetNumerosTarjeteroVisitantesAsync();
        //        }


        //        // Proyecta solo la propiedad NumeroEnTarjetero
        //        var listaNumeros = datosConsulta.Select(d => d.NumeroEnTarjetero).ToList();

        //        // Limpiar cualquier contenido previo en el Grid
        //        gridTarjetero.Children.Clear();
        //        gridTarjetero.RowDefinitions.Clear();
        //        gridTarjetero.ColumnDefinitions.Clear();

        //        // Definir las dimensiones del grid
        //        int totalItems = listaNumeros.Count;
        //        int columnas = 4; // Número de columnas deseadas
        //        int filas = (int)Math.Ceiling((double)totalItems / columnas);

        //        // Crear las definiciones de fila y columna dinámicamente
        //        for (int i = 0; i < filas; i++)
        //        {
        //            gridTarjetero.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        //        }

        //        for (int i = 0; i < columnas; i++)
        //        {
        //            gridTarjetero.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
        //        }

        //        // Agregar los botones dinámicamente
        //        for (int i = 0; i < totalItems; i++)
        //        {
        //            int fila = i / columnas;
        //            int columna = i % columnas;

        //            var boton = new Button
        //            {
        //                Text = listaNumeros[i].ToString(),
        //                WidthRequest = 50,
        //                HeightRequest = 50,
        //                BackgroundColor = Color.White,
        //                TextColor = Color.FromHex("#004F73"),
        //            };

        //            // Agregar el botón al Grid
        //            gridTarjetero.Children.Add(boton, columna, fila);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await DisplayAlert("Error", $"Ocurrió un problema al cargar los datos: {ex.Message}", "OK");
        //    }
        //}


        private async void CargarNumerosTarjetero(string tipoUsuario)
        {
            try
            {
                // Obtén los datos según el tipo de usuario
                var datosConsulta = tipoUsuario == "Empleado"
                    ? await App.Context.GetNumerosTarjeteroEmpleadosAsync()
                    : tipoUsuario == "Visitante"
                    ? await App.Context.GetNumerosTarjeteroVisitantesAsync()
                    : await App.Context.GetNumerosTarjeteroDisponiblesAsync();


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

                    var numero = listaNumeros[i];

                    var boton = new Button
                    {
                        Text = listaNumeros[i].ToString(),
                        CornerRadius = 10,
                        WidthRequest = 60,
                        HeightRequest = 60,
                        BackgroundColor = Color.FromHex("#0091EA"),
                        FontFamily = "ManropeBold",
                        FontSize = 16,
                        TextColor = Color.FromHex("#000000"),
                    };

                    // Asignar el evento Clicked al botón
                    boton.Clicked += (sender, e) => Boton_Clicked(sender, numero);

                    gridTarjetero.Children.Add(boton, columna, fila);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un problema al cargar los datos: {ex.Message}", "OK");
            }
        }

        private Button botonSeleccionado;  // Variable global para almacenar el último botón seleccionado

        // Manejador del evento Clicked
        private async void Boton_Clicked(object sender, int numero)
        {
            // Cambiar el color del botón previamente seleccionado, si existe
            if (botonSeleccionado != null)
            {
                botonSeleccionado.BackgroundColor = Color.White; // Restablecer color original
                botonSeleccionado.TextColor = Color.FromHex("#004F73"); // Restablecer color del texto original
            }

            // Cambiar el color del botón seleccionado
            if (sender is Button boton)
            {
                boton.BackgroundColor = Color.FromHex("#4CAF50"); // Color verde claro
                boton.TextColor = Color.White; // Cambiar el color del texto si es necesario

                // Guardar la referencia del botón seleccionado
                botonSeleccionado = boton;
            }

            // Mostrar el número seleccionado
            await DisplayAlert("Número seleccionado", $"Has seleccionado el número: {numero}", "OK");
        }

        private async void CargarTipoUsuario()
        {
            try
            {
                // Consulta SQL: Obtén los datos con el modelo de la base de datos
                var datosConsulta = await App.Context.GetTipoUsuarioAsync();

                // Filtra los tipos de usuarios que sean "Empleado" o "Visitante"
                var listaTipoUsuarios = datosConsulta
                    .Where(d => d._TipoUsuario == "Empleado" || d._TipoUsuario == "Visitante")
                    .Select(d => d._TipoUsuario)
                    .ToList();

                // Enlaza los datos al Picker
                tipoUsuarioPicker.ItemsSource = listaTipoUsuarios;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un problema al cargar los datos: {ex.Message}", "OK");
            }
        }


        // Evento que se ejecuta al cargar la página
        protected override void OnAppearing()
        {
            base.OnAppearing();
            CargarTiposIdentificacion();
            CargarEmpresas();
            CargarLocaciones();
            CargarTipoUsuario();            
        }

        // Método para manejar el evento SelectedIndexChanged
        private void OnTipoUsuarioPickerChanged(object sender, EventArgs e)
        {
            if (tipoUsuarioPicker.SelectedIndex != -1)
            {
                // Obtiene el elemento seleccionado
                string selectedOption = tipoUsuarioPicker.SelectedItem.ToString();

                CargarNumerosTarjetero(selectedOption);
            }
        }

        private async void ButtonGuardar_Clicked(object sender, EventArgs e)
        {
            string textoDelBoton = "0";

            try
            {
                if (botonSeleccionado != null)
                {
                    textoDelBoton = botonSeleccionado.Text;
                }

                var UsuarioNuevo = new Usuario
                {
                    IdentificacionUsuario = IdentificacionEntry.Text,
                    TipoDocumentoUsuario = (tipoIdentificacionPicker.SelectedItem as string) ?? "No seleccionado",
                    NombreUsuario = NombreEntry.Text,
                    GeneroUsuario = (GeneroPicker.SelectedItem as string) ?? "No seleccionado",
                    CargoUsuario = CargoEntry.Text,
                    CelularUsuario = CelularEntry.Text,
                    CorreoUsuario = correoEntry.Text,
                    EstadoEmpleado = "Activo",
                    EPSEmpleado = EPSEntry.Text,
                    ARLEmpleado = ARLEntry.Text,
                    TipoSangreUsuario = (bloodTypePicker.SelectedItem as string) ?? "No seleccionado",
                    NombreContactoEmergencia = ContactoEmergenciaEntry.Text,
                    NumeroContactoEmergencia = NumeroEmergenciaEntry.Text,
                    TipoUsuario = (tipoUsuarioPicker.SelectedItem as string) ?? "No seleccionado",
                    NumeroTarjetero = textoDelBoton,
                    Pass = IdentificacionEntry.Text,
                    Empresa = (tipoEmpresaPicker.SelectedItem as string) ?? "No seleccionado",
                    Locacion = (tipoLocacionPicker.SelectedItem as string) ?? "No seleccionado"
                };

                // Recuperar valores de los controles
                var empresa = (tipoEmpresaPicker.SelectedItem as string) ?? "No seleccionado";
                var locacion = (tipoLocacionPicker.SelectedItem as string) ?? "No seleccionado";

                await App.Context.InsertUsuarioAsyn(UsuarioNuevo);
                await App.Context.UpdateTarjeteroAsync(empresa, locacion, textoDelBoton);

                await DisplayAlert("Exito", $"Usuario cargado correctamente", "OK");

                // Volver a cargar los numeros de tarjetero despues de guardar el nuevo usuario
                //if (tipoUsuarioPicker.SelectedIndex != -1)
                //{
                //    // Obtiene el elemento seleccionado
                //    string selectedOption = tipoUsuarioPicker.SelectedItem.ToString();

                //    CargarNumerosTarjetero(selectedOption);
                //}

                // Limpia los campos después de guardar
                LimpiarCampos();

                
            }
            catch (Exception ex) {
                await DisplayAlert("Error", $"Ocurrió un problema al cargar los datos: {ex.Message}", "OK");
            }
        }

        private void LimpiarCampos()
        {
            // Restablecer Entry
            IdentificacionEntry.Text = string.Empty;
            NombreEntry.Text = string.Empty;
            CargoEntry.Text = string.Empty;
            CelularEntry.Text = string.Empty;
            EPSEntry.Text = string.Empty;
            ARLEntry.Text = string.Empty;
            ContactoEmergenciaEntry.Text = string.Empty;
            NumeroEmergenciaEntry.Text = string.Empty;
            correoEntry.Text = string.Empty;

            // Restablecer Picker seleccionados
            tipoIdentificacionPicker.SelectedIndex = -1;
            GeneroPicker.SelectedIndex = -1;
            bloodTypePicker.SelectedIndex = -1;
            tipoEmpresaPicker.SelectedIndex = -1;
            tipoLocacionPicker.SelectedIndex = -1;
            tipoUsuarioPicker.SelectedIndex = -1;

            gridTarjetero.Children.Clear();

        }


    }
}