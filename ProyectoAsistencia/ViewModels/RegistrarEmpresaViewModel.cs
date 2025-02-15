using ProyectoAsistencia.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoAsistencia.ViewModels
{
    public class RegistrarEmpresaViewModel : BaseViewModel
    {
        public Command RegistrarEmpresaCommand { get; }

        public RegistrarEmpresaViewModel()
        {
            RegistrarEmpresaCommand = new Command(OnRegistrarEmpresaClicked);
        }

        private async void OnRegistrarEmpresaClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
