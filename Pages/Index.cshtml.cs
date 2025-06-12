using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using OmdbApp.Models;
using OmdbApp.Services;

namespace OmdbApp.Pages
{
    public class IndexModel : PageModel
    {        
        private readonly OmdbMovieQueryService _omdbService;

        [BindProperty(SupportsGet = true)]
        public string? Title { get; set; }

        [BindProperty(SupportsGet = true)]
        [Range(1888, 2100, ErrorMessage = "Please enter a valid year.")]
        public int? Year { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ErrorMessage { get; set; }
        public bool HasSearched { get; set; } = false;

        public OmdbQueryServiceResult<List<OmdbMovieQueryResult>>? SearchResults { get; set; }

        public IndexModel(OmdbMovieQueryService omdbService)
        {
            _omdbService = omdbService;
        }
       
        public async Task OnGetAsync()
        {
            // Don't throw up an invalid title error unless a search as been initiated.
            HasSearched = HttpContext.Request.Query.ContainsKey("title") || HttpContext.Request.Query.ContainsKey("year");
                        
            if (!string.IsNullOrWhiteSpace(Title))
            {
                SearchResults = await _omdbService.SearchAsync(Title, Year);
                if (SearchResults.HasError)
                {
                    ErrorMessage = SearchResults.ErrorMessage;
                    SearchResults.Data = null;
                }
            }
            else
            {
                ErrorMessage = "Please enter a movie title.";
            }
        }
    }
}
