namespace PostApi.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public int AuthorId { get; set; }
        public int Likes { get; set; }
        public decimal Popularity { get; set; }
        public int Reads { get; set; }
        public string[] Tags { get; set; }
    }
}
