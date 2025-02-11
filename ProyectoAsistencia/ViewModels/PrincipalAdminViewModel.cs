using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProyectoAsistencia.Models;
using ProyectoAsistencia.Views;
using Xamarin.Forms;

namespace ProyectoAsistencia.ViewModels
{
    class PrincipalAdminViewModel : BaseViewModel
    {

        public ICommand CrearInformeCommand { get; }
        public ICommand GestionUsuariosCommand { get; }
        public ICommand PanelAdminCommand { get; }
        


        public PrincipalAdminViewModel() {

            

            //CrearInformeCommand = new Command(async () => await NavegarACrearInforme());
            //GestionUsuariosCommand = new Command(async () => await NavegarAGestionUsuarios());
            //PanelAdminCommand = new Command(async () => await NavegarAPanelAdmin());
        }

        public void EsAdminPrincipal(string tipoUsaurio)
        {

        }

        //private async Task NavegarACrearInforme()
        //{
        //    await Application.Current.MainPage.Navigation.PushAsync(new CrearInformePage());
        //}

        //private async Task NavegarAGestionUsuarios()
        //{
        //    await Application.Current.MainPage.Navigation.PushAsync(new GestionUsuariosPage());
        //}

        //private async Task NavegarAPanelAdmin()
        //{
        //    await Application.Current.MainPage.Navigation.PushAsync(new PanelAdminPage());
        //}

    }
}
