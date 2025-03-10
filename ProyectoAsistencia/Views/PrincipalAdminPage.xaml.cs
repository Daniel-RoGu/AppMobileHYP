﻿using ProyectoAsistencia.Data;
using ProyectoAsistencia.Models;
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
	public partial class PrincipalAdminPage : ContentPage
	{

        string identificacion = "";
        string pass = "";
        ExportarExcel exportarExcel = new ExportarExcel();

        public PrincipalAdminPage (string identificacion, string pass)
		{			
            this.identificacion = identificacion;
            this.pass = pass;
            EsAdminPrincipal();
            InitializeComponent();
        }

        //public PrincipalAdminPage()
        //{
        //    InitializeComponent();
        //}

        private async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            // Redirige a la página 'SecondPage'
            await Navigation.PushAsync(new PrincipalEmpleadoPage());
        }

        private async void OnCrearInformeClicked(object sender, EventArgs e)
        {
            try
            {
                var confirm = await Application.Current.MainPage.DisplayAlert(
                    "Aviso",
                    "Desea enviar por correo el informe regular de asistencia",
                    "Sí", "No");

                if (confirm)
                {
                    exportarExcel.GenerateAndSendExcel("ReporteNormal");
                }

                await Task.Delay(2000); // Espera 5 segundos

                confirm = await Application.Current.MainPage.DisplayAlert(
                    "Aviso",
                    "Desea enviar por correo el informe de la asistencia del modo emergencia",
                    "Sí", "No");

                if (confirm)
                {
                    exportarExcel.GenerateAndSendExcel("ModoEmergencia");
                }                
                
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error al acceder al informe", $"{ex.Message}", "OK");
            }
        }

        private async void OnGestionUsuariosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MostrarUsuarioPage(identificacion, pass));
        }

        private async void OnPanelAdministradorClicked(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(identificacion) && !string.IsNullOrEmpty(pass))
            {                
                 await Navigation.PushAsync(new MenuAdminPrincipalPage());                
            }
        }

        private async void OnPanelDevClicked(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(identificacion) && !string.IsNullOrEmpty(pass))
            {
                
                await Navigation.PushAsync(new ArranqueDevPage());
                
            }
        }

        public async void EsAdminPrincipal()
        {
            bool respuesta = await App.Context.ExisteUsuarioAsync(identificacion, pass);
            bool esAdminPrincipal = await App.Context.ExisteUsuarioAdminPrincipalAsync(identificacion, pass);
            bool esDev = await App.Context.ExisteUsuarioDevAsync(identificacion, pass);

            if (respuesta == true && esAdminPrincipal == true)
            {
                SlAdminFirst.IsVisible = true;                

                if (esDev == true)
                {
                    SlDev.IsVisible = true;
                }

            }

        }

        private async void Button_NewPass(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(identificacion) && !string.IsNullOrEmpty(pass))
            {                                
                    await Navigation.PushAsync(new NewPassPage(identificacion));                
            }
        }

    }
}