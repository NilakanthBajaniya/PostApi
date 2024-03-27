using PostApi.Controllers;
using PostApi.Services;
using PostApi.Services.Interfaces;
using PostApi.Services.Utils;
using PostApi.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace PostApi.Controllers
{
    public class GetPostsQueryParams
    {
        [Required(ErrorMessage = "tags parameter is required")]
        public string Tags { get; set; }
        [StringRange(
            AllowableValues = new[] { PostSortFields.Id, PostSortFields.Reads, PostSortFields.Likes, PostSortFields.Popularity },
            ErrorMessage = "sortBy parameter is invalid"
        )]
        public string SortBy { get; set; } = PostSortFields.Id;
        [StringRange(
            AllowableValues = new[] { SortDirection.Asc, SortDirection.Desc }, 
            ErrorMessage = "direction parameter is invalid"
        )]
        public string Direction { get; set; } = SortDirection.Asc;
    }
}
