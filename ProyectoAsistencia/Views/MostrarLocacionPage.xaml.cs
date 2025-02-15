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
	public partial class MostrarLocacionPage : ContentPage
	{
        private string idbusqueda = "";
        public MostrarLocacionPage ()
		{
			InitializeComponent ();
            this.BindingContext = new MostrarLocacionViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            LoadItems();

            var viewModel = BindingContext as MostrarLocacionViewModel;
            if (viewModel != null)
            {
                viewModel.Locaciones.Clear();
                var locaciones = await App.Context.GetItemsAsyncLocacion();
                foreach (var locacion in locaciones)
                {
                    viewModel.Locaciones.Add(locacion);
                }
            }
        }

        private async void LoadItems()
        {
            try
            {
                // Obtén los datos según si se esta buscando un usuario o no
                var items = !string.IsNullOrEmpty(idbusqueda)
                    ? await App.Context.GetLocacionBuscada(idbusqueda)
                    : await App.Context.GetItemsAsyncLocacion();

                //var items = await App.Context.GetItemsAsyncLocacion();
                Lista_Locaciones.ItemsSource = items;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al cargar empresas: {ex.Message}");
            }
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            // Obtener el objeto de la locacion desde el CommandParameter
            var locacionAEliminar = (Locacion)((Button)sender).CommandParameter;


            var confirm = await Application.Current.MainPage.DisplayAlert(
                "Eliminar",
                $"¿Estás seguro de que deseas eliminar la empresa '{locacionAEliminar.NombreLocacion}'?",
                "Sí", "No");

            if (confirm)
            {
                int eliminado = await App.Context.InutilizarLocacion(locacionAEliminar);

                await Application.Current.MainPage.DisplayAlert("Éxito", "Empresa eliminada correctamente", "OK");

                // Navegar a la nueva página de forma asíncrona
                await Navigation.PushAsync(new MostrarLocacionPage());
            }

        }

        private async void BtnEdit_Clicked(object sender, EventArgs e)
        {
            // Obtener la locacion seleccionada desde el CommandParameter
            var locacionAEditar = (Locacion)((Button)sender).CommandParameter;

            // Crear la página de edición y pasarle la empresa a editar
            var editPage = new EditarLocacionPage(locacionAEditar);

            // Mostrar la página como un modal
            await Navigation.PushAsync(editPage);
        }

        private async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            // Redirige a la página 'SecondPage'
            await Navigation.PushAsync(new PrincipalEmpleadoPage());
        }

        //BUSCADOR INDIVIDUAL DE LOCACIONES
        private void OnSearchBarTextChanged(object sender, EventArgs e)
        {
            idbusqueda = LocacionesSearchBar.Text;

            LoadItems();
        }

        private async void OnHomeClicked(object sender, EventArgs e)
        {
            // Redirige a la página 'SecondPage'
            await Navigation.PushAsync(new PrincipalEmpleadoPage());
        }

        private async void OnAddLocacionClicked(object sender, EventArgs e)
        {
            // Redirige a la página 'SecondPage'
            await Navigation.PushAsync(new RegistrarLocacionPage());
        }
    }
}