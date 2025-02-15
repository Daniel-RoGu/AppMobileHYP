using ProyectoAsistencia.Models;
using ProyectoAsistencia.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoAsistencia.ViewModels
{   

    internal class MostrarUsuarioViewModel : BaseViewModel
    {

        public Command MostrarUsuarioCommand { get; }
        public ObservableCollection<Usuario> Usuarios { get; set; }
        public ICommand EliminarCommand { get; }

        private bool _esAdminVisible;
        public bool EsAdminVisible
        {
            get => _esAdminVisible;
            set
            {
                if (_esAdminVisible != value)
                {
                    _esAdminVisible = value;
                    OnPropertyChanged(nameof(EsAdminVisible));
                }
            }
        }

        public MostrarUsuarioViewModel()
        {
            MostrarUsuarioCommand = new Command(OnMostrarUsuarioClicked);

            // Inicializar la colección
            Usuarios = new ObservableCollection<Usuario>();

            // Inicializar el comando
            EliminarCommand = new Command<Usuario>(EliminarUsuario);
        }

        private async void OnMostrarUsuarioClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        private async void EliminarUsuario(Usuario usuario)
        {
            if (usuario == null)
                return;

            // Mostrar alerta de confirmación
            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Confirmación",
                $"¿Estás seguro de que deseas eliminar la empresa {usuario.IdentificacionUsuario}?",
                "Sí", "No");

            if (confirm)
            {
                // Eliminar de la base de datos
                await App.Context.DeleteUsuarioAsync(usuario);

                // Actualizar la lista
                Usuarios.Remove(usuario);

                // Mostrar un mensaje al usuario
                await Application.Current.MainPage.DisplayAlert("Éxito", "Empresa eliminada correctamente", "OK");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
