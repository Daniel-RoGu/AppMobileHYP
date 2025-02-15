using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using ProyectoAsistencia.Models;
using ProyectoAsistencia.Views;
using Xamarin.Forms;

namespace ProyectoAsistencia.ViewModels
{
    public class MostrarEmpresaViewModel : BaseViewModel
    {
        public Command MostrarEmpresaCommand { get; }
        public ObservableCollection<Empresa> Empresas { get; set; }
        public ICommand EliminarCommand { get; }


        public MostrarEmpresaViewModel()
        {
            MostrarEmpresaCommand = new Command(OnMostrarEmpresaClicked);

            // Inicializar la colección
            Empresas = new ObservableCollection<Empresa>();

            // Inicializar el comando
            EliminarCommand = new Command<Empresa>(EliminarEmpresa);
        }

        private async void OnMostrarEmpresaClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        private async void EliminarEmpresa(Empresa empresa)
        {
            if (empresa == null)
                return;

            // Mostrar alerta de confirmación
            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Confirmación",
                $"¿Estás seguro de que deseas eliminar la empresa {empresa.NombreEmpresa}?",
                "Sí", "No");

            if (confirm)
            {
                // Eliminar de la base de datos
                await App.Context.DeleteItemAsync(empresa);

                // Actualizar la lista
                Empresas.Remove(empresa);

                // Mostrar un mensaje al usuario
                await Application.Current.MainPage.DisplayAlert("Éxito", "Empresa eliminada correctamente", "OK");
            }

        }


    }
}
