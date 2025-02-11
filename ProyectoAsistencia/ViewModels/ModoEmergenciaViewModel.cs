using ProyectoAsistencia.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace ProyectoAsistencia.ViewModels
{
    internal class ModoEmergenciaViewModel : BaseViewModel
    {
        public Command ModoEmergenciaCommand { get; }

        public ModoEmergenciaViewModel()
        {
            ModoEmergenciaCommand = new Command(OnModoEmergenciaClicked);
        }

        private async void OnModoEmergenciaClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
