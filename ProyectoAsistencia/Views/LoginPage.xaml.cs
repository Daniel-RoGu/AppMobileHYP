using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //var admin = new Usuario
            //{
            //    IdentificacionUsuario = "0000",
            //    TipoUsuario = "Desarrollador",
            //    Pass = "0000"
            //};

            //await App.Context.InsertUsuarioAsyn(admin);

            var identificacion = identificacionEntry.Text;
            var pass = contrasenaEntry.Text;

            if (!string.IsNullOrEmpty(identificacion) && !string.IsNullOrEmpty(pass))
            {

                bool respuesta = await App.Context.ExisteUsuarioAsync(identificacion, pass);

                if (respuesta == true)
                {
                    await Navigation.PushAsync(new PrincipalAdminPage(identificacion, pass));
                }
            }
        }
    }
}