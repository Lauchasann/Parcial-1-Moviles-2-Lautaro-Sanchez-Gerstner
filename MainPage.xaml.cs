using Parcial1.ViewModels;
using Parcial1.Models;
using Parcial1.Views;

namespace Parcial1;

public partial class MainPage : ContentPage
{
    private MainViewModel vm;

    public MainPage()
    {
        InitializeComponent();

        vm = new MainViewModel();

        vm.DetalleSolicitado += async (post) =>
        {
            await Navigation.PushAsync(new DetailPage(post));
        };

        BindingContext = vm;
    }
}