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
        private bool degradado = false;
        public string title  { get; set; }
        public string label  { get; set; }
        
        public string button_text { get; set; }
        

        public AsignacionAdminOnePage ()
		{
			InitializeComponent ();
            AssignTitle();
		}
        
        public AsignacionAdminOnePage (bool esDegrado)
		{
            degradado = esDegrado;
			InitializeComponent ();
            AssignTitle();
        }

        private void AssignTitle()
        {
            if (degradado)
            {
                title = "Degradar administrador"; // Asigna el título a la página
                label = "Formulario para degradadar un administrador";
                button_text = "Degradar";
            }
            else
            {
                title = "Ascender administrador"; // Asigna el título a la página
                label = "Formulario para ascender un usuario a administrador";
                button_text = "Ascender";
            }
            
            this.BindingContext = this;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            identificacion = identificacionEntry.Text;

            try
            {
                if (!string.IsNullOrEmpty(identificacion))
                {
                    if (degradado == false)
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
                        // si es degradado, genero un string que sirva como titulo de la vista
                        // de tal forma que si la vista recibe el constructor de degradado 
                        // el titulo no sera "Ascender a nuevo..." sino, "Degradar..." 
                        // Mostrar confirmación antes de proceder
                        bool confirmacion = await Application.Current.MainPage.DisplayAlert(
                            "Confirmar",
                            $"¿Está seguro de actualizar al usuario con identificación '{identificacion}' como empleado?",
                            "Sí",
                            "No"
                        );

                        // Solo procede si el usuario confirma
                        if (confirmacion)
                        {
                            await App.Context.UpdateDesUsuarioComoEmpleadoAsync(identificacion);
                            await Application.Current.MainPage.DisplayAlert("Éxito", "Usuario actualizado correctamente", "OK");
                            await Navigation.PushAsync(new MenuAdminPrincipalPage());
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Cancelado", "Operación cancelada por el usuario", "OK");
                        }
                        
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