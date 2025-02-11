using ProyectoAsistencia.Models;
using ProyectoAsistencia.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;


namespace ProyectoAsistencia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostrarUsuarioPage : ContentPage
    {

        private string idbusqueda = "";
        string identificacion = "";
        string pass = "";
        bool interruptorAdminPrincipal = false; //habilita la vista de todos los tipos de empleados cuando el usuario logeado es in administrador principal
        bool interruptorBlockAdmin = false;
        public ObservableCollection<Usuario> UsuariosRef { get; set; }

        public MostrarUsuarioPage()
        {
            InitializeComponent();
            OnAppearing();
        }

        public MostrarUsuarioPage(string identificacionRef, string passRef)
        {
            InitializeComponent();
            OnAppearing();
            
            identificacion = identificacionRef;
            pass = passRef;
            EsAdminPrincipal();           
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            LoadItems();

            var viewModel = BindingContext as MostrarUsuarioViewModel;

            if (viewModel != null)
            {
                viewModel.Usuarios.Clear();
                var usuarios = await App.Context.GetUsuariosAsync();
                foreach (var usuario in usuarios)
                {
                    viewModel.Usuarios.Add(usuario);
                }
            }

            

        }

        private async void LoadItems()
        {
            try
            {

                // Obtén los datos según si se esta buscando un usuario o no
                //var items = !string.IsNullOrEmpty(idbusqueda) && interruptorAdminPrincipal != true
                //    ? await App.Context.GetUsuarioBuscado(idbusqueda)
                //    : await App.Context.GetUsuariosAsync();

                var items = !string.IsNullOrEmpty(idbusqueda) && interruptorAdminPrincipal != true
                            ? await App.Context.GetUsuarioBuscado(idbusqueda)
                            : interruptorAdminPrincipal == true
                                ? await App.Context.GetUsuariosTodosAsync()
                                : await App.Context.GetUsuariosAsync();

                // Convertir List a ObservableCollection
                //UsuariosRef = new ObservableCollection<ProyectoAsistencia.Models.Usuario>(items);

                //var items = await App.Context.GetUsuariosAsync();

                var referencia = new List<Usuario>();
                var empresaRef = "Sin definir";
                var locacionRef = "Sin definir";
                var numeroTarjeteroRef = "Sin definir";

                if (items != null)
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].NumeroTarjetero != null && items[i].NumeroTarjetero != "")
                        {
                            var datosConsulta = await App.Context.GetNombreInfoNumeroTarjetero(Convert.ToInt32(items[i].NumeroTarjetero));
                            empresaRef = datosConsulta.EmpresaAsociada;
                            locacionRef = datosConsulta.LocacionAsociada;
                            numeroTarjeteroRef = items[i].NumeroTarjetero;
                        }

                        referencia.Add(new Usuario
                        {
                            IdentificacionUsuario = items[i].IdentificacionUsuario,
                            TipoDocumentoUsuario = items[i].TipoDocumentoUsuario,
                            NombreUsuario = items[i].NombreUsuario,
                            GeneroUsuario = items[i].GeneroUsuario,
                            CargoUsuario = items[i].CargoUsuario,
                            CelularUsuario = items[i].CelularUsuario,
                            CorreoUsuario = items[i].CorreoUsuario,
                            EstadoEmpleado = items[i].EstadoEmpleado,
                            EPSEmpleado = items[i].EPSEmpleado,
                            ARLEmpleado = items[i].ARLEmpleado,
                            TipoSangreUsuario = items[i].TipoSangreUsuario,
                            NumeroContactoEmergencia = items[i].NumeroContactoEmergencia,
                            NombreContactoEmergencia = items[i].NombreContactoEmergencia,
                            TipoUsuario = items[i].TipoUsuario,
                            NumeroTarjetero = numeroTarjeteroRef,
                            Empresa = empresaRef,
                            Locacion = locacionRef
                        });

                        //if (items[i].TipoUsuario == "Administrador")
                        //{
                        //    BotonInhabilitarAdmin();
                        //}
                    }

                    // Asignando la consulta a una lista en la vista
                    Lista_Usuarios.ItemsSource = referencia;
                    //await Application.Current.MainPage.DisplayAlert("Éxito", "Usuarios cargados correctamente", "OK");
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al cargar usuarios: {ex.Message}");
            }
        }

        private async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            // Redirige a la página 'SecondPage'
            await Navigation.PushAsync(new LoginPage());
        }

        public ObservableCollection<Usuario> Usuarios { get; set; }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            // Obtener el objeto de la empresa desde el CommandParameter
            var usuarioAEliminar = (Usuario)((Button)sender).CommandParameter;


            var confirm = await Application.Current.MainPage.DisplayAlert(
                "Eliminar",
                $"¿Estás seguro de que deseas eliminar la usuario '{usuarioAEliminar.IdentificacionUsuario}'?",
                "Sí", "No");

            if (confirm)
            {
                int eliminado = await App.Context.InutilizarUsuario(usuarioAEliminar);

                await Application.Current.MainPage.DisplayAlert("Éxito", "Usuario eliminado correctamente", "OK");

                // Navegar a la nueva página de forma asíncrona
                await Navigation.PushAsync(new MostrarUsuarioPage());
            }

        }


        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }


        private async void BtnEdit_Clicked(object sender, EventArgs e)
        {
            // Obtener la usuario seleccionada desde el CommandParameter
            var usuarioAEditar = (Usuario)((Button)sender).CommandParameter;

            // Crear la página de edición y pasarle la empresa a editar
            var editPage = new EditarUsuarioPage(usuarioAEditar);

            // Mostrar la página como un modal
            await Navigation.PushAsync(editPage);
        }      
        
        //BUSCADOR INDIVIDUAL DE USUARIOS
        private void OnSearchBarTextChanged(object sender, EventArgs e)
        {
            idbusqueda = EmpleadoSearchBar.Text;

            LoadItems();
        }

        private async void OnDesAdminClicked(object sender, EventArgs e)
        {
            // Redirige a la página 'SecondPage'
            await Navigation.PushAsync(new DesHabilitarAdminPage());
        }

        private async void OnHomeClicked(object sender, EventArgs e)
        {
            // Redirige a la página 'SecondPage'
            await Navigation.PushAsync(new PrincipalEmpleadoPage());
        }

        private async void OnAddUserClicked(object sender, EventArgs e)
        {
            // Redirige a la página 'SecondPage'
            await Navigation.PushAsync(new RegistrarUsuarioPage());
        }

        public async void EsAdminPrincipal()
        {
            bool respuesta = await App.Context.ExisteUsuarioAsync(identificacion, pass);
            bool esAdmin = await App.Context.ExisteUsuarioAdminPrincipalAsync(identificacion, pass);

            if (respuesta && esAdmin)
            {
                interruptorAdminPrincipal = true;
                LoadItems();
            }

        }

        //private void OnItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    // Verifica que se haya seleccionado un item
        //    if (e.Item != null)
        //    {
        //        // Aquí tienes acceso al índice del item seleccionado
        //        int index = Lista_Usuarios.ItemsSource.Cast<object>().ToList().IndexOf(e.Item);

        //        // Accede a la celda correspondiente y luego al botón
        //        var viewCell = Lista_Usuarios.TemplatedItems.ElementAtOrDefault(index) as ViewCell;
        //        if (viewCell != null)
        //        {
        //            // Obtén el botón dentro de la celda
        //            var boton = viewCell.FindByName<Button>("BotonInhabilitarAdmin");
        //            if (boton != null)
        //            {
        //                // Ahora puedes cambiar la propiedad IsVisible
        //                if (interruptorAdminPrincipal != false && interruptorBlockAdmin != false)
        //                {
        //                    boton.IsVisible = true;
        //                }
        //                else
        //                {
        //                    boton.IsVisible = false;
        //                }
        //            }
        //        }

        //        // Desmarcar la selección
        //        Lista_Usuarios.SelectedItem = null;
        //    }
        //}

        //private void OcultarBotonInhabilitarAdmin(Usuario usuarioSeleccionado, bool ocultar)
        //{
        //    // Verifica que el usuario seleccionado no sea nulo
        //    if (usuarioSeleccionado == null) return;

        //    // Iterar sobre las celdas actuales del ListView (basado en ItemsSource)
        //    foreach (var item in Lista_Usuarios.ItemsSource)
        //    {
        //        // Si el elemento corresponde al usuario seleccionado
        //        if (item == usuarioSeleccionado)
        //        {
        //            // Buscar la celda activa
        //            var cell = Lista_Usuarios.TemplatedItems.FirstOrDefault(c => c.BindingContext == item) as ViewCell;
        //            if (cell != null)
        //            {
        //                // Acceder al StackLayout por su nombre
        //                var layout = cell.FindByName<StackLayout>("mainControlLayout");
        //                if (layout != null)
        //                {
        //                    // Encontrar el botón dentro del StackLayout
        //                    var boton = layout.FindByName<Button>("BotonInhabilitarAdmin");
        //                    if (boton != null)
        //                    {
        //                        boton.IsVisible = !ocultar; // Oculta o muestra el botón
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        //private void Lista_Usuarios_ItemSelected(object sender, ItemTappedEventArgs e)
        //{
        //    if (e.Item is Usuario usuarioSeleccionado)
        //    {
        //        // Lógica para decidir si se oculta el botón
        //        bool ocultar = usuarioSeleccionado.TipoUsuario == "Administrador";
        //        OcultarBotonInhabilitarAdmin(usuarioSeleccionado, ocultar);
        //    }

        //    // Desactivar la selección visual del elemento en la lista
        //    ((ListView)sender).SelectedItem = null;
        //}

        //private void BotonInhabilitarAdmin()
        //{
        //    // Iterar sobre los elementos visibles del ListView
        //    foreach (var cell in Lista_Usuarios.TemplatedItems)
        //    {
        //        if (cell is ViewCell viewCell)
        //        {
        //            // Buscar el StackLayout por su nombre
        //            var layout = viewCell.FindByName<StackLayout>("mainControlLayout");
        //            if (layout != null)
        //            {
        //                // Encontrar el botón dentro del StackLayout
        //                var boton = layout.FindByName<Button>("BotonInhabilitarAdmin");
        //                if (boton != null)
        //                {
        //                    // Cambiar la visibilidad del botón
        //                    boton.IsVisible = true;
        //                }
        //            }
        //        }
        //    }

        //}

        //private async void BotonInhabilitarAdmin_Clicked_1(object sender, EventArgs e)
        //{
        //    await App.Context.UpdateTipoUserDesAdminAsync(identificacion);
        //}

        //private void BotonInhabilitarAdmin()
        //{
        //    // Iterar sobre los elementos visibles del ListView
        //    foreach (var cell in Lista_Usuarios.TemplatedItems)
        //    {
        //        if (cell is ViewCell viewCell)
        //        {
        //            // Buscar el StackLayout por su nombre
        //            var layout = viewCell.FindByName<StackLayout>("mainControlLayout");
        //            if (layout != null)
        //            {
        //                // Verificar si ya existe un botón con un nombre específico
        //                var botonExistente = layout.Children
        //                    .OfType<Button>()
        //                    .FirstOrDefault(b => b.AutomationId == "BotonInhabilitarAdmin");

        //                // Si no existe, agregar un nuevo botón
        //                if (botonExistente == null)
        //                {
        //                    var nuevoBoton = new Button
        //                    {
        //                        Text = "Inhabilitar Admin",
        //                        BackgroundColor = Color.Red,
        //                        TextColor = Color.White,
        //                        Margin = new Thickness(5),
        //                        AutomationId = "BotonInhabilitarAdmin", // Identificador único
        //                        Command = new Command(() =>
        //                        {
        //                            // Acción cuando se presiona el botón
        //                            Console.WriteLine("Botón 'Inhabilitar Admin' presionado");
        //                        })
        //                    };

        //                    // Asociar el evento Clicked al método existente
        //                    nuevoBoton.Clicked += BotonInhabilitarAdmin_Clicked_1;

        //                    layout.Children.Add(nuevoBoton);
        //                }
        //            }
        //        }
        //    }
        //}

    }
}        

  