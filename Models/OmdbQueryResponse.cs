using System.Text.Json.Serialization;

namespace OmdbApp.Models
{
    public class OmdbQueryResponse
    {
        [JsonPropertyName("Search")]
        public List<OmdbMovieQueryResult> Search { get; set; } = [];

        [JsonPropertyName("totalResults")]
        public string? TotalResults { get; set; }

        [JsonPropertyName("Response")]
        public string? Response { get; set; }

        [JsonPropertyName("Error")]
        public string? Error { get; set; }
    }
}
