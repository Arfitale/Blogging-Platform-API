using System.Text.Json.Serialization;

namespace App.Models
{
    public class Blog
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public required string Title { get; set; }

        [JsonPropertyName("content")]
        public required string Content { get; set; }

        [JsonPropertyName("author_id")]
        public required string AuthorId { get; set; }

        [JsonPropertyName("create_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
