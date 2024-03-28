using PostApi.DataAccess.Interfaces;
using PostApi.Models;
using PostApi.Models.DTOs;
using System.Net.Http.Json;

namespace PostApi.HttpClients
{
    public class PostApiClient : IPostApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly PostApiResponseDTO _emptyPostApiResponseDTO;

        public PostApiClient(HttpClient client)
        {
            _httpClient = client;

            _emptyPostApiResponseDTO = new()
            {
                Posts = new List<Post>(),
            };
        }

        public async Task<PostApiResponseDTO> GetPostsByTag(string tag)
        {
            var posts = await _httpClient.GetFromJsonAsync<PostApiResponseDTO>($"?tag={tag}");
            if (posts == null)
            {
                return _emptyPostApiResponseDTO;
            }

            return posts;
        }
    }
}
