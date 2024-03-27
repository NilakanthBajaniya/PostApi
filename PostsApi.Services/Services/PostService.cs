using PostApi.HttpClients;
using PostApi.Models;
using PostApi.Services.Interfaces;
using PostApi.Services.Utils;
using PostApi.Models.DTOs;
using System.ComponentModel;
using System.Xml.Linq;

namespace PostApi.Services
{
    public enum SortField
    {
        Id,
        Reads,
        Likes,
        Popularity
    }

    public static class PostSortFields
    {
        public const string Id = "id";
        public const string Reads = "reads";
        public const string Likes = "likes";
        public const string Popularity = "popularity";
    }

    public class PostService : IPostService
    {
        private readonly PostApiClient _apiClient;
        public PostService(PostApiClient apiClient)
        {
            _apiClient = apiClient;
        }


        public async Task<PostApiResponseDTO> GetByTags(List<string> tags, string sortBy, string direction)
        {
            Dictionary<int, Post> postIdToPostsDict = new();

            foreach (string tag in tags)
            {
                PostApiResponseDTO postResponse = await _apiClient.GetPostsByTag(tag);
                foreach (Post post in postResponse.Posts)
                {
                    if (!postIdToPostsDict.ContainsKey(post.Id))
                    {
                        postIdToPostsDict.Add(post.Id, post);
                    }
                }
            }

            return new()
            {
                Posts = SortPosts(postIdToPostsDict.Values, sortBy, direction),
            };
        }

        private IEnumerable<Post> SortPosts(IEnumerable<Post> posts, string sortField, string direction)
        {
            switch (sortField)
            {
                case PostSortFields.Id:
                    {
                        posts = posts.OrderBy(post => post.Id);
                        break;
                    }
                case PostSortFields.Reads:
                    {
                        posts = posts.OrderBy(post => post.Reads);
                        break;
                    }
                case PostSortFields.Likes:
                    {
                        posts = posts.OrderBy(post => post.Likes);
                        break;
                    }
                case PostSortFields.Popularity:
                    {
                        posts = posts.OrderBy(post => post.Popularity);
                        break;
                    }
                default:
                    {
                        posts = posts.OrderBy(post => post.Id);
                        break;
                    }
            }

            return direction == SortDirection.Desc ?
                    posts.Reverse() :
                    posts;
        }

        //private IEnumerable<Post> SortPosts(IEnumerable<Post> posts, SortField sortField, string direction)
        //{
        //    switch (sortField)
        //    {
        //        case SortField.Reads:
        //            {
        //                posts = posts.OrderBy(post => post.Reads);
        //                break;
        //            }
        //        case SortField.Likes:
        //            {
        //                posts = posts.OrderBy(post => post.Likes);
        //                break;
        //            }
        //        case SortField.Popularity:
        //            {
        //                posts = posts.OrderBy(post => post.Popularity);
        //                break;
        //            }
        //        default:
        //            {
        //                posts = posts.OrderBy(post => post.Id);
        //                break;
        //            }

        //    }

        //    return direction == "desc" ?
        //            posts.Reverse() :
        //            posts;
        //}
    }

}
