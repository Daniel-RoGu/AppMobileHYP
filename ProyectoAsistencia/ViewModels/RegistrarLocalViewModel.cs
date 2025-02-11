using ProyectoAsistencia.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoAsistencia.ViewModels
{
    class RegistrarLocalViewModel : BaseViewModel
    {
        public Command RegistrarLocalCommand { get; }

        public RegistrarLocalViewModel()
        {
            RegistrarLocalCommand = new Command(OnRegistrarLocalClicked);
        }

        private async void OnRegistrarLocalClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
