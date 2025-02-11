using ProyectoAsistencia.Models;
using ProyectoAsistencia.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoAsistencia.ViewModels
{
    class MostrarLocacionViewModel : BaseViewModel
    {
        public Command MostrarLocacionCommand { get; }
        public ObservableCollection<Locacion> Locaciones { get; set; }
        public ICommand EliminarCommand { get; }

        public MostrarLocacionViewModel()
        {
            MostrarLocacionCommand = new Command(OnMostrarLocacionClicked);

            // Inicializar la colección
            Locaciones = new ObservableCollection<Locacion>();

            // Inicializar el comando
            EliminarCommand = new Command<Locacion>(EliminarLocacion);
        }

        private async void OnMostrarLocacionClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        private async void EliminarLocacion(Locacion locacion)
        {
            if (locacion == null)
                return;

            // Mostrar alerta de confirmación
            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Confirmación",
                $"¿Estás seguro de que deseas eliminar la empresa {locacion.NombreLocacion}?",
                "Sí", "No");

            if (confirm)
            {
                // Eliminar de la base de datos
                await App.Context.DeleteLocacionAsync(locacion);

                // Actualizar la lista
                Locaciones.Remove(locacion);

                // Mostrar un mensaje al usuario
                await Application.Current.MainPage.DisplayAlert("Éxito", "Empresa eliminada correctamente", "OK");
            }

        }
    
    }
}
