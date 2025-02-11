using System.ComponentModel;
using ProyectoAsistencia.ViewModels;
using Xamarin.Forms;

namespace ProyectoAsistencia.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}