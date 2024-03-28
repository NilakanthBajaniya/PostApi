using PostApi.Models.DTOs;

namespace PostApi.Services.Interfaces
{
    public interface IPostService
    {
        Task<PostApiResponseDTO> GetByTags(List<string> tags, string sortBy, string direction);
    }
}
