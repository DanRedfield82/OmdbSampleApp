﻿using System.Text.Json.Serialization;

namespace OmdbApp.Models
{
    public class OmdbMovieQueryResult
    {
        [JsonPropertyName("Title")]
        public string? Title { get; set; }

        [JsonPropertyName("Year")]
        public string? Year { get; set; }

        [JsonPropertyName("imdbID")]
        public string? ImdbID { get; set; }

        [JsonPropertyName("Type")]
        public string? Type { get; set; }

        [JsonPropertyName("Poster")]
        public string? Poster { get; set; }
    }
}