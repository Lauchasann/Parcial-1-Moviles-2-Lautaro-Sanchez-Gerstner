using CommunityToolkit.Mvvm.ComponentModel;
using Parcial1.Models;
using Parcial1.Models;

namespace Parcial1.ViewModels
{
    public partial class DetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private Post postSeleccionado;
    }
}