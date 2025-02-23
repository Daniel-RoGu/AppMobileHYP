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
        private string rutaImg;

        public RegistrarEmpresaPage()
        {
            InitializeComponent();
            this.BindingContext = new RegistrarEmpresaViewModel();
        }

        private async void ButtonGuardar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rutaImg))
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
                    EstadoEmpresa = "Activo"
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

        //private async void OnSelectImageClicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

        //        Console.WriteLine(status);

        //        if (status != PermissionStatus.Granted)
        //        {
        //            // Si no se muestra la explicación, es posible que el usuario haya denegado permanentemente el permiso
        //            if (!Permissions.ShouldShowRationale<Permissions.StorageRead>())
        //            {
        //                var abrirConfiguracion = await DisplayAlert(
        //                    "Permiso denegado",
        //                    "Para continuar, debes habilitar el permiso de lectura de almacenamiento en la configuración de la app.",
        //                    "Abrir configuración",
        //                    "Cancelar");

        //                if (abrirConfiguracion)
        //                {
        //                    AppInfo.ShowSettingsUI();
        //                }
        //            }
        //            else
        //            {
        //                // Solicitar permiso normalmente
        //                status = await Permissions.RequestAsync<Permissions.StorageRead>();
        //            }
        //        }

        //        if (status == PermissionStatus.Granted)
        //        {
        //            var fileResult = await FilePicker.PickAsync(new PickOptions
        //            {
        //                PickerTitle = "Selecciona una imagen",
        //                FileTypes = FilePickerFileType.Images
        //            });

        //            if (fileResult != null)
        //            {
        //                var stream = await fileResult.OpenReadAsync();
        //                var fileName = fileResult.FileName;

        //                var rootPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        //                var imgFolderPath = Path.Combine(rootPath, "img");

        //                if (!Directory.Exists(imgFolderPath))
        //                    Directory.CreateDirectory(imgFolderPath);

        //                var filePath = Path.Combine(imgFolderPath, fileName);

        //                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        //                {
        //                    await stream.CopyToAsync(fileStream);
        //                }

        //                rutaImg = filePath;
        //                await DisplayAlert("Éxito", "El logo se ha cargado correctamente.", "OK");
        //            }
        //        }
        //        else
        //        {
        //            await DisplayAlert("Aviso", "El permiso sigue denegado.", "OK");
        //        }

        //        Console.WriteLine(status);
        //    }
        //    catch (Exception ex)
        //    {
        //        await DisplayAlert("Error", $"No se pudo cargar la imagen: {ex.Message}", "OK");
        //    }
        //}

        private async void OnSelectImageClicked(object sender, EventArgs e)
        {
            try
            {
                // Verificar el permiso de lectura del almacenamiento
                var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.StorageRead>();
                }
                if (status != PermissionStatus.Granted)
                {
                    await DisplayAlert("Error", "Permiso denegado para leer el almacenamiento.", "OK");
                    return;
                }

                // Usamos MediaPicker para seleccionar una imagen.
                var photo = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Selecciona una imagen"
                });

                if (photo == null)
                    return; // El usuario canceló la operación

                // Abrir el stream de la imagen seleccionada
                using (var stream = await photo.OpenReadAsync())
                {
                    // Si el FileName está vacío (lo que puede suceder en Android 14), se genera uno
                    var fileName = string.IsNullOrWhiteSpace(photo.FileName)
                        ? $"{Guid.NewGuid()}.jpg"
                        : photo.FileName;

                    // Definir la carpeta 'img' en el directorio local de la app
                    var rootPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var imgFolderPath = Path.Combine(rootPath, "img");

                    if (!Directory.Exists(imgFolderPath))
                        Directory.CreateDirectory(imgFolderPath);

                    // Definir la ruta completa donde se guardará la imagen
                    var filePath = Path.Combine(imgFolderPath, fileName);

                    // Copiar el contenido del stream a un archivo local
                    using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        await stream.CopyToAsync(fileStream);
                    }

                    // Actualizar la variable (o UI) con la ruta del archivo local
                    rutaImg = filePath;
                    await DisplayAlert("Éxito", "La imagen se ha cargado correctamente.", "OK");
                }
            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlert("Error", "Esta función no es soportada en este dispositivo.", "OK");
            }
            catch (PermissionException)
            {
                await DisplayAlert("Error", "Permiso denegado.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"No se pudo cargar la imagen: {ex.Message}", "OK");
            }
        }


    }
}

