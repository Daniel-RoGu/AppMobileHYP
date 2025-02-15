using System;
using ProyectoAsistencia.Data;
using ProyectoAsistencia.Services;
using ProyectoAsistencia.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAsistencia
{
    public partial class App : Application
    {
        public static DataBaseContext Context { get; set; }
        public App()
        {
            InitializeComponent();
            InitializeDatabase();

            DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();
            MainPage = new NavigationPage(new PrincipalEmpleadoPage());
            //MainPage = new NavigationPage(new RegistrarEmpresaPage());
            //MainPage = new NavigationPage(new MostrarEmpresaPage());
            //MainPage = new NavigationPage(new RegistrarLocacionPage());
            //MainPage = new NavigationPage(new MostrarLocacionPage());
            //MainPage = new NavigationPage(new RegistrarUsuarioPage());
            //MainPage = new NavigationPage(new MostrarUsuarioPage());
            //MainPage = new NavigationPage(new ArranqueDevPage());

        }

        private void InitializeDatabase()
        {
            var folderApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dbPath = System.IO.Path.Combine(folderApp, "Asistencia.db3");
            Context = new DataBaseContext(dbPath);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
