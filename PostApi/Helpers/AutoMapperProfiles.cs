using AutoMapper;
using PostApi.Models.DTOs;

namespace PostApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PostApiResponseDTO, PostResponse>()
            .ForMember(
                dest => dest.Count,
                opt => opt.MapFrom(src => src.Posts.Count())
            );

        }
    }
}
