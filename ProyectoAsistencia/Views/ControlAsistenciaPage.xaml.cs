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
    public partial class ControlAsistenciaPage : ContentPage
    {

        private bool interruptorAsistencia = false;
        private string userRef = "";
        private string fechaActual = "";
        private string horaActual = "";
        private List<Hora> horas = new List<Hora>();

        public ControlAsistenciaPage(string IdRef)
        {
            InitializeComponent();

            // Garantiza la busqueda de la identificacion del usuario 
            obtenerUser(IdRef);
            //Console.WriteLine(userRef);
            //ControlLabelEstadoAsistencia();
        }

        public async void obtenerUser(string referencia)
        {
            var user = await App.Context.GetUsuarioIndividual(referencia);            

            userRef = user != null
                      ? user.IdentificacionUsuario
                      : null;

            Console.WriteLine(userRef);
            ControlLabelEstadoAsistencia();
        }
        
        public async void obtenerEstadoAsistencia(string referencia)
        {
            if (userRef != "")
            {
                var asistencia = await App.Context.GetHorariosUsuario(referencia);
                horas = asistencia;

                // accede al ultimo registro de asistencia y compara su estado 
                interruptorAsistencia = asistencia != null && asistencia.LastOrDefault()?.EstadoHora == "Ausente"
                                        ? false
                                        : true;

                Console.WriteLine(asistencia);
            }           
                        
        }

        private async void AsistenciaSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            // Acceder al switch
            var switchControl = (Switch)sender;

            // Gestion fecha y hora actual
            //ObtenerFechaHoraActual();
            FechaActual();

            try
            {
                Asistencia asistencia = new Asistencia()
                {
                    FechaSincronizacion = "Sin actualizar",
                    FechaAsistencia = fechaActual,
                    EstadoAsistencia = "Valido"
                };

                await App.Context.InsertAsistenciaDefault(asistencia);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error en Asistencia", $"Ocurrió un problema al cargar los datos: {ex.Message}", "OK");
            }

            try
            {                
                // Crear objeto `Hora` según el estado del interruptor
                Hora hora = new Hora()
                {
                    HoraLlegada = e.Value ? horaActual : "Sin Registro",
                    HoraSalida = e.Value ? "Sin Registro" : horaActual,
                    EstadoHora = e.Value ? "Ausente" : "Presente",
                    AsistenciaRelacionada = fechaActual,
                    UsuarioRelacionado = userRef,
                };
                
                await App.Context.InsertHoraDefault(hora);
                
                                
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error en Hora", $"Ocurrió un problema al cargar los datos: {ex.Message}", "OK");
            }

            ControlLabelEstadoAsistencia();

        }

        private async void ControlLabelEstadoAsistencia()
        {
            //obtenerEstadoAsistencia(userRef);

            if (userRef != "")
            {
                var asistencia = await App.Context.GetHorariosUsuario(userRef);
                horas = asistencia;

                // accede al ultimo registro de asistencia y compara su estado 
                interruptorAsistencia = asistencia != null && asistencia.LastOrDefault()?.EstadoHora == "Ausente"
                                        ? false
                                        : true;

                Console.WriteLine(asistencia);
            }

            if (interruptorAsistencia)
            {
                LabelEstadoAsistencia.Text = "Presente";
                // Actualiza el Switch en función del Label
                AsistenciaSwitch.IsToggled = LabelEstadoAsistencia.Text == "Presente";
            }
            else
            {
                LabelEstadoAsistencia.Text = "Ausente";
            }

        }

        // Metodo para obtener la fecha actual en el sistema de zona horaria Bogota
        //public void ObtenerFechaHoraActual()
        //{
        //    TimeZoneInfo zonaHorariaColombia;

        //    try
        //    {
        //        // Intentar con el identificador de Windows
        //        zonaHorariaColombia = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
        //    }
        //    catch (TimeZoneNotFoundException)
        //    {
        //        try
        //        {
        //            // Intentar con el identificador de IANA (para Linux/macOS)
        //            zonaHorariaColombia = TimeZoneInfo.FindSystemTimeZoneById("America/Bogota");
        //        }
        //        catch (TimeZoneNotFoundException)
        //        {
        //            // Si falla, usar UTC como fallback
        //            Console.WriteLine("No se pudo encontrar la zona horaria de Colombia. Usando UTC.");
        //            zonaHorariaColombia = TimeZoneInfo.Utc;
        //        }
        //    }

        //    // Hora UTC actual
        //    DateTime utcNow = DateTime.UtcNow;

        //    // Convertir a hora de Colombia
        //    DateTime horaColombia = TimeZoneInfo.ConvertTimeFromUtc(utcNow, zonaHorariaColombia);

        //    // Mostrar la fecha actual
        //    fechaActual = horaColombia.ToString("dd/MM/yyyy");

        //    // Obtener solo la hora (ejemplo: "14:35:00")
        //    horaActual = horaColombia.ToString("HH:mm:ss");
           
        //}

        public void FechaActual()
        {
            // Obtener la zona horaria del dispositivo en Android
            TimeZoneInfo zonaHorariaLocal = TimeZoneInfo.Local;

            // Hora UTC actual
            DateTime utcNow = DateTime.UtcNow;

            // Convertir a la hora local del dispositivo
            DateTime horaLocal = TimeZoneInfo.ConvertTimeFromUtc(utcNow, zonaHorariaLocal);

            // Formatear fecha y hora
            fechaActual = horaLocal.ToString("dd/MM/yyyy");
            horaActual = horaLocal.ToString("HH:mm:ss");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PrincipalEmpleadoPage());
        }
    }
}