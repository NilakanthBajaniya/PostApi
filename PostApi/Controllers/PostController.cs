using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PostApi.Controllers;
using PostApi.Services;
using PostApi.Services.Interfaces;
using PostApi.Models.DTOs;

namespace PostsApi.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postsService;
        private readonly IMapper _mapper;

        public PostController(PostService postsService, IMapper mapper)
        {
            _postsService = postsService;
            _mapper = mapper;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PostResponse>> GetPosts([FromQuery] GetPostsQueryParams query)

        {
            List<string> tagsArray = query.Tags.Replace(" ", "").Split(",").ToList();

            PostApiResponseDTO postsApiResponse = 
                    await _postsService.GetByTags(tagsArray, query.SortBy, query.Direction);

            PostResponse response = _mapper.Map<PostResponse>(postsApiResponse);
            return Ok(response);
        }
    }
}
