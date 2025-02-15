using ProyectoAsistencia.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoAsistencia.ViewModels
{
    public class UsuarioViewModel : BaseViewModel
    {

        public Command usaurioCommand { get; }

        public UsuarioViewModel()
        {
            usaurioCommand = new Command(OnPrincipalUsaurioClicked);
        }

        private async void OnPrincipalUsaurioClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

    }
}
