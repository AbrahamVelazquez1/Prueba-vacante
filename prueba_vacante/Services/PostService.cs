using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

using prueba_vacante.Models;

namespace prueba_vacante.Services
{
    public class PostService : IPostService
    {
        private readonly HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Post>>("posts")
                ?? new List<Post>();
        }

        public async Task<Post?> GetPostByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Post>($"posts/{id}");
        }

        public async Task<Post?> CreatePostAsync(Post post)
        {
            var response = await _httpClient.PostAsJsonAsync("posts", post);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Post>();
            }
            return null;
        }

        public async Task<bool> UpdatePostAsync(int id, Post post)
        {
            var response = await _httpClient.PutAsJsonAsync($"posts/{id}", post);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"posts/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}