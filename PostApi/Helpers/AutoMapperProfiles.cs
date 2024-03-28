using AutoMapper;
using PostApi.DTOs;
using PostApi.Models.DTOs;
using PostApi.Services;
using PostApi.Services.Utils;

namespace PostApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PostApiResponseDTO, PostResponse>()
                .AfterMap((src, dest) => dest.Meta = new()
                {
                    Count = src.Posts.Count(),
                    SortOptions = new List<string>
                    {
                        PostSortFields.Id, 
                        PostSortFields.Reads, 
                        PostSortFields.Likes, 
                        PostSortFields.Popularity,
                    },
                    SortDirections = new List<string>
                    {
                        SortDirection.Asc,
                        SortDirection.Desc,
                    }
                });

        }
    }
}
