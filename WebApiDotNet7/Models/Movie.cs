namespace WebApiDotNet7.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ActorName { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}
