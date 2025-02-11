using ProyectoAsistencia.Models;
using ProyectoAsistencia.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAsistencia.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DesHabilitarAdminPage : ContentPage
	{

        public Usuario usuarios { get; set; }

        private string idbusqueda = "";
        string identificacion = "";
        string pass = "";

        public DesHabilitarAdminPage ()
		{
			InitializeComponent ();

        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Obtener la usuario seleccionada desde el CommandParameter
            var usuarioAEditar = (Usuario)((Button)sender).CommandParameter;

            string idref = usuarioAEditar.IdentificacionUsuario;
            string numref = usuarioAEditar.NumeroTarjetero;
            int success = await App.Context.UpdateTipoUserDesAdminAsync(idref, numref);

            if (success == 1)
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

                var items = !string.IsNullOrEmpty(idbusqueda) 
                            ? await App.Context.GetUsuarioBuscado(idbusqueda)
                            : await App.Context.GetUsuariosAdminActivos();

                var referencia = new List<Usuario>();

                if (items != null)
                {
                    for (int i = 0; i < items.Count; i++)
                    {

                        referencia.Add(new Usuario
                        {
                            IdentificacionUsuario = items[i].IdentificacionUsuario,
                            NombreUsuario = items[i].NombreUsuario,
                            CargoUsuario = items[i].CargoUsuario,
                            CelularUsuario = items[i].CelularUsuario,
                            CorreoUsuario = items[i].CorreoUsuario,
                            TipoUsuario = items[i].TipoUsuario,
                            NumeroTarjetero = items[i].NumeroTarjetero
                        });

                        
                    }

                    // Asignando la consulta a una lista en la vista
                    Lista_Usuarios.ItemsSource = referencia;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al cargar usuarios: {ex.Message}");
            }
        }

        private void OnSearchBarTextChanged(object sender, EventArgs e)
        {
            idbusqueda = AdmisSearchBar.Text;

            LoadItems();
        }

    }
}