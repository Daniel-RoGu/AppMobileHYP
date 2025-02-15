using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoAsistencia.ViewModels;
using ProyectoAsistencia.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace ProyectoAsistencia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarEmpresaPage : ContentPage
    {
        public Empresa Empresa { get; set; }
        private string _nuevoLogoPath;

        public EditarEmpresaPage(Empresa empresa)
        {
            InitializeComponent();
            Empresa = empresa;
            BindingContext = Empresa;

            // Precargar los datos actuales en el formulario
            EntryNombre.Text = empresa.NombreEmpresa;
            EntryNIT.Text = empresa.NITEmpresa;
            if (!string.IsNullOrEmpty(empresa.LogoEmpresa))
                LogoPreview.Source = ImageSource.FromFile(empresa.LogoEmpresa);
        }

        // Método para guardar los cambios
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Aquí se guarda los cambios en la base de datos.
            bool success = await ActualizarEmpresa(Empresa);

            if (success)
            {
                await DisplayAlert("Éxito", "Los cambios se han guardado correctamente.", "OK");
                await Navigation.PopAsync(); // Volver a la página anterior.
            }
            else
            {
                await DisplayAlert("Error", "No se pudo guardar los cambios.", "OK");
            }
        }

        // Método para cancelar los cambios
        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // Volver a la página anterior sin guardar cambios.
        }

        // Método para actualizar los datos de la empresa en la base de datos.
        private async Task<bool> ActualizarEmpresa(Empresa empresa)
        {
            if (_nuevoLogoPath == "" || _nuevoLogoPath == null)
            {
                _nuevoLogoPath = "Sin logo";
            }

            var item = new Empresa
            {
                NombreEmpresa = EntryNombre.Text,
                NITEmpresa = EntryNIT.Text,
                LogoEmpresa = _nuevoLogoPath,
                EstadoEmpresa = PickerEstado.SelectedItem.ToString(),
            };

            int result = await App.Context.UpdateEmpresaAsync(item);

            if (result == 1)
            {
                return await Task.FromResult(true); // Simulación de éxito.
            }
            else
            {
                return await Task.FromResult(false); // Simulación de éxito.
            }

        }

        private async void OnSelectLogoClicked(object sender, EventArgs e)
        {
            

            try
            {
                // Permitir al usuario seleccionar un archivo de imagen
                var fileResult = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Selecciona un nuevo logo",
                    FileTypes = FilePickerFileType.Images
                });

                if (fileResult != null)
                {
                    var stream = await fileResult.OpenReadAsync();
                    var fileName = fileResult.FileName;

                    // Guardar el nuevo logo en la carpeta 'img'
                    var rootPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var imgFolderPath = Path.Combine(rootPath, "img");

                    if (!Directory.Exists(imgFolderPath))
                        Directory.CreateDirectory(imgFolderPath);

                    _nuevoLogoPath = Path.Combine(imgFolderPath, fileName);

                    using (var fileStream = new FileStream(_nuevoLogoPath, FileMode.Create, FileAccess.Write))
                    {
                        await stream.CopyToAsync(fileStream);
                    }

                    // Mostrar la imagen en la vista previa
                    LogoPreview.Source = ImageSource.FromFile(_nuevoLogoPath);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"No se pudo cargar el logo: {ex.Message}", "OK");
            }

        }

    }

}