using Moq;
using PostApi.Models.DTOs;
using PostApi.Models;
using PostApi.Services.Interfaces;
using PostsApi.Controllers;
using AutoMapper;
using PostApi.Services.Utils;
using PostApi.Services;
using PostApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace PostApi.Tests
{
    public class PostControllerTests
    {
        private List<Post> _posts;
        private PostApiResponseDTO _response;
        private GetPostsQueryParams _queryParams;
        private PostResponse _controllerResponse;
        private List<string> _tags = new() { "tech" };

        private Mock<IPostService> _postServiceMock;
        private Mock<IMapper> _mapperMock;
        private PostController _postController;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _postServiceMock = new Mock<IPostService>();

            _posts = new()
            {
                new Post
                {
                    Id = 1,
                    Author = "Author1",
                    AuthorId = 1,
                    Likes = 100,
                    Popularity = 0.12m,
                    Reads = 100,
                    Tags = new[] {"tech", "history"}
                },
                new Post
                {
                    Id = 2,
                    Author = "Author2",
                    AuthorId = 2,
                    Likes = 200,
                    Popularity = 0.22m,
                    Reads = 200,
                    Tags = new[] {"tech"}
                }
            };
            _response = new()
            {
                Posts = _posts,
            };

            _controllerResponse = new()
            {
                Meta = new()
                {
                    Count = _posts.Count,
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
                }
            };

            _queryParams = new()
            {
                Tags = "tech",
            };

            _postServiceMock.Setup(service => service.GetByTags(_tags, "id", "asc"))
                .ReturnsAsync(_response);

            _mapperMock.Setup(mapper => mapper.Map<PostResponse>(_response))
                .Returns(_controllerResponse);

            _postController = new PostController(_postServiceMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task Post_GetByTags_CheckMethodInvoked()
        {
            await _postController.GetPosts(_queryParams);

            _postServiceMock.Verify(service => service.GetByTags(_tags, "id", "asc"), Times.Once);
        }

        [Test]
        public async Task Post_GetPost_ReturnsExpectedResponse()
        {
            var result = await _postController.GetPosts(_queryParams);

            var controllerResponse = result.Result as OkObjectResult;
            Assert.That(controllerResponse?.Value, Is.Not.Null);
            Assert.That(controllerResponse.Value, Is.TypeOf<PostResponse>());
        }
    }
}