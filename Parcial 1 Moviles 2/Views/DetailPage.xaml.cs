using Parcial1.ViewModels;
using Parcial1.Models;
using Parcial1.ViewModels;

namespace Parcial1.Views;

public partial class DetailPage : ContentPage
{
    public DetailPage(Post post)
    {
        InitializeComponent();

        BindingContext = new DetailViewModel
        {
            PostSeleccionado = post
        };
    }
}