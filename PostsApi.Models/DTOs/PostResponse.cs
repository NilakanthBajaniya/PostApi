
namespace PostApi.Models.DTOs
{
    public class PostResponse
    {
        public int Count { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
