using Moq;
using PostApi.DataAccess.Interfaces;
using PostApi.HttpClients;
using PostApi.Models;
using PostApi.Models.DTOs;

namespace PostApi.Services.Tests
{
    public class PostServiceTests
    {
        private List<Post> _posts;
        private PostApiResponseDTO _response;

        private Mock<IPostApiClient> _postApiClientMock;
        private PostService _postService;

        [SetUp]
        public void Setup()
        {
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

            _postApiClientMock = new Mock<IPostApiClient>();

            _postApiClientMock.Setup(client => client.GetPostsByTag("tech"))
                .ReturnsAsync(_response);

            _postService = new PostService(_postApiClientMock.Object);
        }

        [Test]
        public async Task GetByTags_InvokeMethod_CheckIfGetPostsByTagIsCalled()
        {
            List<string> tags = new() { "tech" };
            await _postService.GetByTags(tags, "id", "asc");

            _postApiClientMock.Verify(client =>  client.GetPostsByTag(tags[0]), Times.Once);
        }

        [Test]
        public async Task Post_GetByTags_ReturnsDataWithTags()
        {
            List<string> tags = new() { "tech" };
            var results = await _postService.GetByTags(tags, "id", "asc");

            Assert.That(results, Is.Not.Null);

            Assert.That(results.Posts.Count() == 2, Is.True);

            Assert.That(
                results.Posts.Select(post => post.Tags).All(tags => tags.Contains("tech")),
                Is.True
             );
        }
    }
}