using PostApi.Models.DTOs;

namespace PostApi.DataAccess.Interfaces
{
    public interface IPostApiClient
    {
        Task<PostApiResponseDTO> GetPostsByTag(string tag);
    }
}
