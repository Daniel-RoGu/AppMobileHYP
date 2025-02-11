using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoAsistencia.ViewModels;
using ProyectoAsistencia.Models;
using System.IO;
using Xamarin.Essentials;

namespace ProyectoAsistencia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarEmpresaPage : ContentPage
    {
        public string rutaImg { get; set; }

        public RegistrarEmpresaPage()
        {
            InitializeComponent();
            this.BindingContext = new RegistrarEmpresaViewModel();
        }

        private async void ButtonGuardar_Clicked(object sender, EventArgs e)
        {
            if (rutaImg == "" || rutaImg == null)
            {
                rutaImg = "Sin logo";
            }

            try
            {
                var item = new Empresa
                {
                    NombreEmpresa = Empresa.Text,
                    NITEmpresa = NIT.Text,
                    LogoEmpresa = rutaImg,
                    EstadoEmpresa = "Activa"
                };

                var result = await App.Context.InsertItemAsyn(item);

                if (result == 1)
                {
                    await DisplayAlert("Éxito", "El cambio ha sido realizado.", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo realizar la tarea", "Aceptar");
                }
            }
            catch(Exception ex) 
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

        private async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            // Redirige a la página 'SecondPage'
            await Navigation.PushAsync(new PrincipalEmpleadoPage());
        }

        private async void OnSelectImageClicked(object sender, EventArgs e)
        {
            try
            {
                // Permitir al usuario seleccionar un archivo
                var fileResult = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Selecciona una imagen",
                    FileTypes = FilePickerFileType.Images // Solo permitir imágenes
                });

                if (fileResult != null)
                {
                    // Obtener el contenido del archivo seleccionado
                    var stream = await fileResult.OpenReadAsync();
                    var fileName = fileResult.FileName;

                    // Definir la carpeta 'img' en el directorio raíz del proyecto
                    var rootPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var imgFolderPath = Path.Combine(rootPath, "img");

                    // Crear la carpeta 'img' si no existe
                    if (!Directory.Exists(imgFolderPath))
                        Directory.CreateDirectory(imgFolderPath);

                    // Definir la ruta completa del archivo
                    var filePath = Path.Combine(imgFolderPath, fileName);

                    // Guardar el archivo en la carpeta 'img'
                    using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        await stream.CopyToAsync(fileStream);
                    }

                    // Actualizar el campo de texto con la ruta del archivo
                    rutaImg = filePath;

                    // Mostrar un mensaje al usuario
                    await DisplayAlert("Éxito", "El logo se ha cargado correctamente.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"No se pudo cargar la imagen: {ex.Message}", "OK");
            }
        }
    }
}