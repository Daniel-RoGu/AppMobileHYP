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
	public partial class AsignacionAdminOnePage : ContentPage
	{
        private string identificacion;
        public AsignacionAdminOnePage ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            identificacion = identificacionEntry.Text;

            try
            {
                if (!string.IsNullOrEmpty(identificacion))
                {
                    // Mostrar confirmación antes de proceder
                    bool confirmacion = await Application.Current.MainPage.DisplayAlert(
                        "Confirmar",
                        $"¿Está seguro de actualizar al usuario con identificación '{identificacion}' como administrador principal?",
                        "Sí",
                        "No"
                    );

                    // Solo procede si el usuario confirma
                    if (confirmacion)
                    {
                        await App.Context.UpdateUsuarioComoAdminOneAsync(identificacion);
                        await Application.Current.MainPage.DisplayAlert("Éxito", "Usuario actualizado correctamente", "OK");
                        await Navigation.PushAsync(new MenuAdminPrincipalPage());
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Cancelado", "Operación cancelada por el usuario", "OK");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "La identificación no puede estar vacía", "OK");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al actualizar usuario como administrador: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error", "Ocurrió un problema al actualizar el usuario", "OK");
            }
        }


    }
}