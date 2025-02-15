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
using Xamarin.Forms.Xaml;

namespace ProyectoAsistencia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostrarEmpresaPage : ContentPage
    {

        private string idbusqueda = "";

        public MostrarEmpresaPage()
        {
            InitializeComponent();
            this.BindingContext = new MostrarEmpresaViewModel();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            LoadItems();

            var viewModel = BindingContext as MostrarEmpresaViewModel;
            if (viewModel != null)
            {
                viewModel.Empresas.Clear();
                var empresas = await App.Context.GetItemsAsync();
                foreach (var empresa in empresas)
                {
                    viewModel.Empresas.Add(empresa);
                }
            }
        }

        private async void LoadItems()
        {
            try
            {
                // Obtén los datos según si se esta buscando un usuario o no
                var items = !string.IsNullOrEmpty(idbusqueda)
                    ? await App.Context.GetEmpresaBuscada(idbusqueda)
                    : await App.Context.GetItemsAsync();

                //var items = await App.Context.GetItemsAsync();
                Lista_Empresas.ItemsSource = items;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al cargar empresas: {ex.Message}");
            }
        }

        private async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            // Redirige a la página 'SecondPage'
            await Navigation.PushAsync(new PrincipalEmpleadoPage());
        }

        //private async void BtnDelete_Clicked(object sender, EventArgs e)
        //{
        //    if (await DisplayAlert("Confirmacion", "¿Está seguro de eliminar el elemento?", "Si", "No"))
        //    {
        //        var item = (Empresa)(sender as MenuItem).CommandParameter;
        //        var resultado = await App.Context.DeleteItemAsync(item);

        //        if (resultado == 1)
        //        {
        //            LoadItems();
        //        }
        //    }
        //}

        public ObservableCollection<Empresa> Empresas { get; set; }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            // Obtener el objeto de la empresa desde el CommandParameter
            var empresaAEliminar = (Empresa)((Button)sender).CommandParameter;

            
                var confirm = await Application.Current.MainPage.DisplayAlert(
                    "Eliminar",
                    $"¿Estás seguro de que deseas eliminar la empresa '{empresaAEliminar.NombreEmpresa}'?",
                    "Sí", "No");

                if (confirm)
                {
                    int eliminado = await App.Context.DeleteItemAsync(empresaAEliminar);

                    await Application.Current.MainPage.DisplayAlert("Éxito", "Empresa eliminada correctamente", "OK");

                    // Navegar a la nueva página de forma asíncrona
                    await Navigation.PushAsync(new MostrarEmpresaPage());
                }
            
        }
        
        private async void BtnEdit_Clicked(object sender, EventArgs e)
        {
            // Obtener la empresa seleccionada desde el CommandParameter
            var empresaAEditar = (Empresa)((Button)sender).CommandParameter;

            // Crear la página de edición y pasarle la empresa a editar
            var editPage = new EditarEmpresaPage(empresaAEditar);

            // Mostrar la página como un modal
            await Navigation.PushAsync(editPage);
        }

        //BUSCADOR INDIVIDUAL DE EMPRESAS
        private void OnSearchBarTextChanged(object sender, EventArgs e)
        {
            idbusqueda = EmpresaSearchBar.Text;

            LoadItems();
        }

        private async void OnHomeClicked(object sender, EventArgs e)
        {
            // Redirige a la página 'SecondPage'
            await Navigation.PushAsync(new PrincipalEmpleadoPage());
        }

        private async void OnAddEmpresaClicked(object sender, EventArgs e)
        {
            // Redirige a la página 'SecondPage'
            await Navigation.PushAsync(new RegistrarEmpresaPage());
        }

    }
}