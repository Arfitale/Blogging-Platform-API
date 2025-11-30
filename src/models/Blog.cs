using System.Text.Json.Serialization;

namespace App.Models
{
    public enum Category
    {
        Technology,
        Lifestyle,
        Travel,
        Food,
        Education,
        Health,
        Finance,
        Entertainment,
        Sports,
        Fashion,
    }

    public class Blog
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public required string Title { get; set; }

        [JsonPropertyName("content")]
        public required string Content { get; set; }

        [JsonPropertyName("category")]
        public required Category Category { get; set; }

        [JsonPropertyName("tags")]
        public string[]? Tags { get; set; }

        [JsonPropertyName("author_id")]
        public required string AuthorId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }

    public class BlogFilter
    {
        public string? Term { get; set; }
        public string? Title { get; set; }
        public string? Category { get; set; }
    }
}
