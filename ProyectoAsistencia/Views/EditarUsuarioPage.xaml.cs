using ProyectoAsistencia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAsistencia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarUsuarioPage : ContentPage
    {

        public Usuario usuarios { get; set; }
        private string numeroActualTarjetero {  get; set; }

        private Button botonSeleccionado;  // Variable global para almacenar el último botón seleccionado

        public EditarUsuarioPage(Usuario usuario)
        {
            InitializeComponent();
            usuarios = usuario;
            BindingContext = usuarios;
            CargarEmpresas();
            CargarLocaciones();
            CargarTipoUsuario();

            // Precargar los datos actuales en el formulario
            EntryIdUsuario.Text = usuario.IdentificacionUsuario;
            EntryTipoDocumento.Text = usuario.TipoDocumentoUsuario;
            EntryNombre.Text = usuario.NombreUsuario;
            PickerGenero.SelectedItem = usuario.GeneroUsuario;
            EntryCargo.Text = usuario.CargoUsuario;
            EntryCelular.Text = usuario.CelularUsuario;
            EntryCorreo.Text = usuario.CorreoUsuario;
            PickerEstadoEmpleado.SelectedItem = usuario.EstadoEmpleado;
            PickerEPS.SelectedItem = usuario.EPSEmpleado;
            PickerARL.SelectedItem = usuario.ARLEmpleado;
            PickerTipoSangre.SelectedItem = usuario.TipoSangreUsuario;            
            EntryNombreContactoEmergencia.Text = usuario.NombreContactoEmergencia;
            EntryNumeroContactoEmergencia.Text = usuario.NumeroContactoEmergencia;
            tipoUsuarioPicker.SelectedItem = usuario.TipoUsuario;
            tipoEmpresaPicker.SelectedItem = usuario.Empresa;
            tipoLocacionPicker.SelectedItem = usuario.Locacion;
            numeroActualTarjetero = usuario.NumeroTarjetero;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {            
            bool success = await ActualizarUsuario(usuarios);

            if (success)
            {
                await DisplayAlert("Éxito", "Los cambios se han guardado correctamente.", "OK");
                //await Navigation.PopAsync(); // Volver a la página anterior.
                await Navigation.PushAsync(new MostrarUsuarioPage());
            }
            else
            {
                await DisplayAlert("Error", "No se pudo guardar los cambios.", "OK");
            }
        }

        // Método para cancelar los cambios
        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // Volver a la página anterior sin guardar cambios.
        }

        // Método para actualizar los datos de la empresa en la base de datos.
        private async Task<bool> ActualizarUsuario(Usuario usuario)
        {
            var item = new Usuario
            {
                IdentificacionUsuario = EntryIdUsuario.Text,
                TipoDocumentoUsuario = EntryTipoDocumento.Text,
                NombreUsuario = EntryNombre.Text,
                GeneroUsuario = PickerGenero.SelectedItem.ToString(),
                CargoUsuario = EntryCargo.Text,
                CelularUsuario = EntryCelular.Text,
                CorreoUsuario = EntryCorreo.Text,
                EstadoEmpleado = PickerEstadoEmpleado.SelectedItem.ToString(),
                EPSEmpleado = PickerEPS.SelectedItem.ToString(),
                ARLEmpleado = PickerARL.SelectedItem.ToString(),
                TipoSangreUsuario = PickerTipoSangre.SelectedItem.ToString(),
                NombreContactoEmergencia = EntryNombreContactoEmergencia.Text,
                NumeroContactoEmergencia = EntryNumeroContactoEmergencia.Text,
                TipoUsuario = tipoUsuarioPicker.SelectedItem.ToString(),
                NumeroTarjetero = botonSeleccionado.Text,
                Pass = EntryIdUsuario.Text,
                Empresa = tipoEmpresaPicker.SelectedItem.ToString(),
                Locacion = tipoLocacionPicker.SelectedItem.ToString()
            };

            //para actualizar el nuevo numero en el tarjetero
            var numerNuevoEnTarjetero = item.NumeroTarjetero;
            await App.Context.UpdateTarjeteroAsync(item.Empresa, item.Locacion, item.NumeroTarjetero);

            //para limpiar el numero antiguo en el tarjetero
            if (numeroActualTarjetero != "Sin definir" && numeroActualTarjetero != "")
            {
                await App.Context.UpdateDesTarjeteroAsync(numeroActualTarjetero);
            }

            int result = await App.Context.UpdateUsuarioParcialAsync(item);            

            if (result == 1)
            {
                return await Task.FromResult(true); // Simulación de éxito.
            }
            else
            {
                return await Task.FromResult(false); // Simulación de éxito.
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
                        WidthRequest = 60,
                        HeightRequest = 50,
                        BackgroundColor = Color.White,
                        TextColor = Color.FromHex("#004F73"),
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

        private void OnTipoUsuarioPickerChanged(object sender, EventArgs e)
        {
            if (tipoUsuarioPicker.SelectedIndex != -1)
            {
                // Obtiene el elemento seleccionado
                string selectedOption = tipoUsuarioPicker.SelectedItem.ToString();

                CargarNumerosTarjetero(selectedOption);
            }
        }

    }
}