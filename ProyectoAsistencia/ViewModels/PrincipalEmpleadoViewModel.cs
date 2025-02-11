using ProyectoAsistencia.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoAsistencia.ViewModels
{
    public class PrincipalEmpleadoViewModel : BaseViewModel
    {
        public Command PrincipalEmpleadoCommand { get; }

        public PrincipalEmpleadoViewModel()
        {
            PrincipalEmpleadoCommand = new Command(OnPrincipalEmpleadoClicked);
        }

        private async void OnPrincipalEmpleadoClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
