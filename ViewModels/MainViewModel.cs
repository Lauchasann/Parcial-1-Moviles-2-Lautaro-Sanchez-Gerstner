using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Parcial1.Models;
using Parcial1.Services;
using System.Collections.ObjectModel;

namespace Parcial1.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly PostService _postService;

        public MainViewModel()
        {
            _postService = new PostService();
        }

        public Action<Post> DetalleSolicitado;

        [ObservableProperty]
        private ObservableCollection<Post> posts = new();

        [ObservableProperty]
        private string mensaje;

        [RelayCommand]
        public async Task CargarDatos()
        {
            try
            {
                Mensaje = "Cargando datos...";

                var resultado = await _postService.GetPostsAsync();

                Posts = new ObservableCollection<Post>(resultado);

                Mensaje = "Datos cargados correctamente";
            }
            catch (HttpRequestException)
            {
                Mensaje = "Error de conexión";
            }
            catch (Exception)
            {
                Mensaje = "Error inesperado";
            }
        }

        [RelayCommand]
        public void IrADetalle(Post post)
        {
            if (post == null)
                return;

            DetalleSolicitado?.Invoke(post);
        }
    }
}