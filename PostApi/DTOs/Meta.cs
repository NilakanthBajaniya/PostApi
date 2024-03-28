

namespace PostApi.DTOs
{
    public class Meta
    {
        public int Count { get; set; }
        public IEnumerable<string> SortOptions { get; set; }
        public IEnumerable<string> SortDirections { get; set; }
    }
}
