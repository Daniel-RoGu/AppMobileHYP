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
    public partial class MenuAdminPrincipalPage : ContentPage
    {       

        public MenuAdminPrincipalPage()
        {
            InitializeComponent();
            //this.identificador = identificacion;
        }

        private async void Button_GestionEmpresas(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MostrarEmpresaPage());
        }

        private async void Button_GestiónLocaciones(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MostrarLocacionPage());
        }        

        private async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            // Redirige a la página 'SecondPage'
            await Navigation.PushAsync(new PrincipalEmpleadoPage());
        }

        private async void Button_AsignarAdmin(object sender, EventArgs e)
        {
            try
            {
                //if (identificador != null || identificador != "")
                //{
                //    await App.Context.UpdateUsuarioComoAdminAsync(this.identificador);
                //    await Application.Current.MainPage.DisplayAlert("Éxito", $"Usuario {this.identificador}, actualizado como administrador", "OK");
                //}
                await Navigation.PushAsync(new AsignacionAdminPage());
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al actualizar usuario como administrador: {ex.Message}");
            }
        }

        private async void Button_AsignarAdminOne(object sender, EventArgs e)
        {
            try
            {
                //if (identificador != null || identificador != "")
                //{
                //    await App.Context.UpdateUsuarioComoAdminOneAsync(this.identificador);
                //    await Application.Current.MainPage.DisplayAlert("Éxito", $"Usuario {this.identificador}, actualizado como administrador principal", "OK");
                //}

                await Navigation.PushAsync(new AsignacionAdminOnePage());
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al actualizar usuario como administrador principal: {ex.Message}");
            }
        }
        
        private async void Button_DownAdminOne(object sender, EventArgs e)
        {
            try
            {               
                await Navigation.PushAsync(new AsignacionAdminOnePage(true));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al actualizar usuario como administrador principal: {ex.Message}");
            }
        }

    }
}