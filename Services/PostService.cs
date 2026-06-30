using Parcial1.Models;
using System.Net.Http.Json;

namespace Parcial1.Services
{
    public class PostService
    {
        private readonly HttpClient _httpClient;

        public PostService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Post>>(
                "https://jsonplaceholder.typicode.com/posts"
            );
        }
    }
}