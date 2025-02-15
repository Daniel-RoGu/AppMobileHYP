using System;
using Xamarin.Forms;

namespace ProyectoAsistencia.Data.Converters
{
    public class TipoUsuarioToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value.ToString() == "Empleado")
            {
                return true; // Mostrar el botón si tipoUsuario es "Empleado"
            }
            return false; // Ocultar el botón si tipoUsuario no es "Empleado"
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value; // No se requiere conversión en este caso.
        }
    }
}

