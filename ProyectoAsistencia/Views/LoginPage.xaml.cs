using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoAsistencia.Data;
using ProyectoAsistencia.Models;
using ProyectoAsistencia.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAsistencia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //this.BindingContext = new LoginViewModel();            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {           
            var identificacion = identificacionEntry.Text;
            var pass = contrasenaEntry.Text;

            if (!string.IsNullOrEmpty(identificacion) && !string.IsNullOrEmpty(pass))
            {

                bool respuesta = await App.Context.ExisteUsuarioAsync(identificacion, pass);

                if (respuesta == true)
                {
                    await Navigation.PushAsync(new PrincipalAdminPage(identificacion, pass));
                }
                else
                {
                    await DisplayAlert("Error", $"Contraseña o usuario incorrectos", "OK");
                }
            }
        }               

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {                

                if (!string.IsNullOrEmpty(identificacionEntry.Text))
                {
                    Usuario userRef = await App.Context.GetUsuarioIndividual(identificacionEntry.Text);
                    ExportarExcel exportarExcel = new ExportarExcel();

                    var confirm = await Application.Current.MainPage.DisplayAlert(
                    "Eliminar",
                    $"¿Estás seguro de que deseas recuperar la contraseña del usuario: '{userRef.IdentificacionUsuario}'?",
                    "Sí", "No");

                    if (confirm)
                    {
                        // Envia el correo con la nueva pass
                        exportarExcel.SendEmailWithoutAttachment("Recuperacion de contraseña", $"Su nueva contraseña temporal es: {userRef.IdentificacionUsuario}", userRef.CorreoUsuario);
                        
                        // actualiza la nueva pass desde bd
                        await App.Context.UpdatePassUserAdminAsync(userRef.IdentificacionUsuario, userRef.IdentificacionUsuario);

                        await Application.Current.MainPage.DisplayAlert("Éxito", "Recuperacion exitosa", "Aceptar");

                        // Navegar a la nueva página de forma asíncrona
                        await Navigation.PushAsync(new PrincipalEmpleadoPage());
                    }                    
                }
                else
                {
                    await DisplayAlert("Observacion", $"Llenar el campo de identificación es obligatorio para la recuperacion de la contraseña", "Aceptar");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"No se pudo restaurar la contraseña {ex.Message}", "OK");
            }
        }
    }
}