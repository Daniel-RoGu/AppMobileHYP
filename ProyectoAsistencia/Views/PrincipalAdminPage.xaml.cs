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
	public partial class PrincipalAdminPage : ContentPage
	{

        string identificacion = "";
        string pass = "";

        public PrincipalAdminPage (string identificacion, string pass)
		{
			InitializeComponent ();
            this.identificacion = identificacion;
            this.pass = pass;
            EsAdminPrincipal();

        }

        public PrincipalAdminPage()
        {
            InitializeComponent();
        }

        private async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            // Redirige a la página 'SecondPage'
            await Navigation.PushAsync(new PrincipalEmpleadoPage());
        }

        private void OnCrearInformeClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new CrearInformePage());
        }

        private async void OnGestionUsuariosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MostrarUsuarioPage(identificacion, pass));
        }

        private async void OnPanelAdministradorClicked(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(identificacion) && !string.IsNullOrEmpty(pass))
            {

                bool respuesta = await App.Context.ExisteUsuarioAsync(identificacion, pass);
                bool esAdminPrincipal = await App.Context.ExisteUsuarioAdminPrincipalAsync(identificacion, pass);

                if (respuesta == true && esAdminPrincipal == true)
                {
                    await Navigation.PushAsync(new MenuAdminPrincipalPage());
                }
            }
        }

        public async void EsAdminPrincipal()
        {
            bool respuesta = await App.Context.ExisteUsuarioAsync(identificacion, pass);
            bool esAdminPrincipal = await App.Context.ExisteUsuarioAdminPrincipalAsync(identificacion, pass);

            if (respuesta == true && esAdminPrincipal == true)
            {
                var adminButton = new Button
                {
                    Text = "Panel Administrador Principal",
                    BackgroundColor = Color.White,
                    TextColor = Color.FromHex("#004F73"),
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 16
                };

                adminButton.Clicked += OnPanelAdministradorClicked;

                // Agregar el botón a un contenedor de la interfaz, como un StackLayout
                mainStackLayout.Children.Add(adminButton);

            }

        }

        private async void Button_NewPass(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(identificacion) && !string.IsNullOrEmpty(pass))
            {                                
                    await Navigation.PushAsync(new NewPassPage(identificacion));                
            }
        }

    }
}