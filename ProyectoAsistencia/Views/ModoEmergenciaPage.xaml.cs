using ProyectoAsistencia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAsistencia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModoEmergenciaPage : ContentPage
    {
        public ModoEmergenciaPage()
        {
            //InitializeComponent();
            this.BindingContext = new ModoEmergenciaViewModel();
        }
        

        private void OnFrameTapped(object sender, EventArgs e)
        {
            // Tu lógica aquí
            DisplayAlert("Frame Tapped", "¡Has hecho clic en el Frame!", "OK");
        }
    }
}