using ProyectoAsistencia.Models;
using ProyectoAsistencia.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace ProyectoAsistencia.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrarLocacionPage : ContentPage
	{
		public RegistrarLocacionPage ()
		{
			InitializeComponent ();
            this.BindingContext = new RegistrarLocalViewModel();
        }

        private async void ButtonGuardar_Clicked(object sender, EventArgs e)
        {            
            try
            {
                var item = new Locacion
                {
                    NombreLocacion = NombreLocacion.Text,
                    RIG = RIG.Text,
                    NombrePozo = NombrePozo.Text,
                    EstadoLocacion = "Activa"
                };

                var result = await App.Context.InsertItemAsynLocacion(item);

                if (result == 1)
                {
                    await DisplayAlert("Éxito", "El cambio ha sido realizado.", "OK");
                    await Navigation.PopAsync(); // retorna a la pagina anterior
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo realizar la tarea", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

        private async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            // Redirige a la página 'SecondPage'
            await Navigation.PushAsync(new PrincipalEmpleadoPage());
        }
        
    }
}