
using PostApi.DTOs;

namespace PostApi.Models.DTOs
{
    public class PostResponse
    {
        public Meta Meta { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
