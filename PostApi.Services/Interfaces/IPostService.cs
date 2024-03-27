
using PostApi.Models.DTOs;
using PostsApi.Services.Interfaces;

namespace PostApi.Services.Interfaces
{
    public interface IPostService : IService<PostApiResponseDTO>
    {
        Task<PostApiResponseDTO> GetByTags(List<string> tags, string sortBy, string direction);
    }
}
