using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Parcial1.Models;
using Parcial1.Models;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace Parcial1.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
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

                var httpClient = new HttpClient();
                var resultado = await httpClient.GetFromJsonAsync<List<Post>>("https://jsonplaceholder.typicode.com/posts");

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
        public async Task IrADetalle(Post post)
        {
            if (post == null)
                return;

            await Application.Current.MainPage.Navigation.PushAsync(new Views.DetailPage(post));
        }
    }
}