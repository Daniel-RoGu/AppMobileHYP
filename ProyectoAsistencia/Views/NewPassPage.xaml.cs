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
	public partial class NewPassPage : ContentPage
	{
		private string identificador;
		public NewPassPage (string identificacion)
		{
			InitializeComponent ();
			identificador = identificacion;
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var newpass = passEntry.Text;
            
            try
            {
                if (identificador != null && identificador != "")
                {
                    // Mostrar confirmación antes de proceder
                    bool confirmacion = await Application.Current.MainPage.DisplayAlert(
                        "Confirmar",
                        $"¿Está seguro que desea actualizar la contraseña de usuario?",
                        "Sí",
                        "No"
                    );

                    // Solo procede si el usuario confirma
                    if (confirmacion)
                    {
                        await App.Context.UpdatePassUserAdminAsync(identificador, newpass);
                        await Application.Current.MainPage.DisplayAlert("Éxito", "Nueva contraseña de usuario actualizada correctamente", "OK");
                        await Navigation.PushAsync(new MenuAdminPrincipalPage());
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Cancelado", "Operación cancelada por el usuario", "OK");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "La nueva contraaseña no puede estar vacía", "OK");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al actualizar la constraseña del usuario: {ex.Message}");
            }
        }
    }
}