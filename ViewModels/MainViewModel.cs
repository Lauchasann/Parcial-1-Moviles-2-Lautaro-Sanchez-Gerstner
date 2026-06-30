using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Parcial1.Models;
using Parcial1.Services;
using System.Collections.ObjectModel;
using Microsoft.Maui.Devices.Sensors;

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

        [ObservableProperty]
        private string ubicacion;

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

        [RelayCommand]
        public async Task ObtenerUbicacion()
        {
            try
            {
                var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

                if (status != PermissionStatus.Granted)
                {
                    Ubicacion = "Permiso de ubicación denegado";
                    return;
                }

                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync();
                }

                if (location != null)
                {
                    Ubicacion = $"Lat: {location.Latitude}, Lon: {location.Longitude}";
                }
                else
                {
                    Ubicacion = "No se pudo obtener ubicación";
                }
            }
            catch (Exception)
            {
                Ubicacion = "Error al obtener ubicación";
            }
        }
    }
}