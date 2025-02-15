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
    public partial class EditarLocacionPage : ContentPage
    {
        public Locacion locaciones { get; set; }
        public EditarLocacionPage(Locacion locacion)
        {
            InitializeComponent();
            locaciones = locacion;
            BindingContext = locaciones;

            // Precargar los datos actuales en el formulario
            EntryNombre.Text = locacion.NombreLocacion;
            EntryRIG.Text = locacion.RIG;
            EntryPozo.Text = locacion.NombrePozo;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Aquí se guarda los cambios en la base de datos.
            bool success = await ActualizarLocacion(locaciones);

            if (success)
            {
                await DisplayAlert("Éxito", "Los cambios se han guardado correctamente.", "OK");
                await Navigation.PopAsync(); // Volver a la página anterior.
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
        private async Task<bool> ActualizarLocacion(Locacion locacion)
        {
            var item = new Locacion
            {
                NombreLocacion = EntryNombre.Text,
                RIG = EntryRIG.Text,
                NombrePozo = EntryPozo.Text,
                EstadoLocacion = PickerEstado.SelectedItem.ToString(),
            };

            int result = await App.Context.UpdateLocacionAsync(item);

            if (result == 1)
            {
                return await Task.FromResult(true); // Simulación de éxito.
            }
            else
            {
                return await Task.FromResult(false); // Simulación de éxito.
            }

        }

    }
}