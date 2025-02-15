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
	public partial class ArranqueDevPage : ContentPage
	{
		public ArranqueDevPage ()
		{
			InitializeComponent ();
		}

        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //    App.Context.RegistrarTiposUsuarioPorDefecto();
        //    App.Context.RegistrarRangosTarjetero();

        //    var ExisteEmpleado = App.Context.ExisteTipoRangoEmpleadoAsync("Empleados");
        //    var ExisteVisitante = App.Context.ExisteTipoRangoEmpleadoAsync("Visitantes");
        //    int rangoSuperior = 0;            
        //    int rangoInferior = 0;            

        //    if (ExisteEmpleado != null)
        //    {
        //        rangoSuperior = await App.Context.GetValorSuperiorRangoTarjetero("Empleado");

        //        for (int i = 0; i <= rangoSuperior; i++)
        //        {
        //            var tarjeteroNew = new Tarjetero()
        //            {
        //                NumeroEnTarjetero = i,
        //                EstadoNumero = "Disponible",
        //                RangoPertenencia = "Empleados",
        //                EmpresaAsociada = "Sin Asignar",
        //                LocacionAsociada = "Sin Asignar"
        //            };

        //           await App.Context.RegistrarNumeroTarjetero(tarjeteroNew);
        //        }
        //    }

        //    if (ExisteVisitante != null)
        //    {
        //        rangoSuperior = await App.Context.GetValorSuperiorRangoTarjetero("Visitantes");
        //        rangoInferior = await App.Context.GetValorInferiorRangoTarjetero("Visitantes");

        //        for (int i = rangoInferior; i <= rangoSuperior; i++)
        //        {
        //            var tarjeteroNew = new Tarjetero()
        //            {
        //                NumeroEnTarjetero = i,
        //                EstadoNumero = "Disponible",
        //                RangoPertenencia = "Visitantes",
        //                EmpresaAsociada = "Sin Asignar",
        //                LocacionAsociada = "Sin Asignar"
        //            };

        //            await App.Context.RegistrarNumeroTarjetero(tarjeteroNew);
        //        }
        //    }
        //}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.Context.RegistrarTiposUsuarioPorDefecto();
                App.Context.RegistrarTiposDocumentoPorDefecto();
                App.Context.RegistrarRangosTarjetero();

                var ExisteEmpleado = App.Context.ExisteTipoRangoEmpleadoAsync("Empleados");
                var ExisteVisitante = App.Context.ExisteTipoRangoEmpleadoAsync("Visitantes");
                int rangoSuperior = 0;
                int rangoInferior = 0;

                if (ExisteEmpleado != null)
                {
                    rangoSuperior = await App.Context.GetValorSuperiorRangoTarjetero("Empleados");

                    for (int i = 0; i <= rangoSuperior; i++)
                    {
                        var tarjeteroNew = new Tarjetero()
                        {
                            NumeroEnTarjetero = i,
                            EstadoNumero = "Disponible",
                            RangoPertenencia = "Empleados",
                            EmpresaAsociada = "Sin Asignar",
                            LocacionAsociada = "Sin Asignar"
                        };

                        await App.Context.RegistrarNumeroTarjetero(tarjeteroNew);
                    }
                }

                if (ExisteVisitante != null)
                {
                    rangoSuperior = await App.Context.GetValorSuperiorRangoTarjetero("Visitantes");
                    rangoInferior = await App.Context.GetValorInferiorRangoTarjetero("Visitantes");

                    for (int i = rangoInferior; i <= rangoSuperior; i++)
                    {
                        var tarjeteroNew = new Tarjetero()
                        {
                            NumeroEnTarjetero = i,
                            EstadoNumero = "Disponible",
                            RangoPertenencia = "Visitantes",
                            EmpresaAsociada = "Sin Asignar",
                            LocacionAsociada = "Sin Asignar"
                        };

                        await App.Context.RegistrarNumeroTarjetero(tarjeteroNew);
                    }
                }

                var admin = new Usuario
                {
                    IdentificacionUsuario = "0000",
                    TipoUsuario = "Desarrollador",
                    Pass = "0000"
                };

                await App.Context.InsertUsuarioAsyn(admin);

                // Mostrar notificación de éxito
                await Application.Current.MainPage.DisplayAlert(
                    "Éxito",
                    "La acción se ha realizado correctamente.",
                    "OK"
                );

                await Navigation.PushAsync(new PrincipalEmpleadoPage());
            }
            catch (Exception ex)
            {
                // Mostrar error si ocurre un problema
                await DisplayAlert("Error al cargar datos de inicio", $"Ocurrió un problema al cargar los datos: {ex.Message}", "OK");
            }
        }

        private async void ButtonRecet(object sender, EventArgs e)
        {
            try
            {
                App.Context.DeleteItemsArranque();

                // Mostrar notificación de éxito
                await Application.Current.MainPage.DisplayAlert(
                    "Éxito",
                    "La acción se ha realizado correctamente.",
                    "OK"
                );

                await Navigation.PushAsync(new PrincipalEmpleadoPage());
            }
            catch (Exception ex)
            {
                // Mostrar error si ocurre un problema
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    $"Ocurrió un problema: {ex.Message}",
                    "OK"
                );
            }
        }
    }
}