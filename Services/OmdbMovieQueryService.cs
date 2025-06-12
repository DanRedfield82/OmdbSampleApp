using Microsoft.Extensions.Options;
using OmdbApp.Models;

namespace OmdbApp.Services
{
    /// <summary>
    /// Implementation of <see cref="IOmdbQueryService"/> that queries the OMDb API for movie data.
    /// </summary>
    /// <param name="httpClient">Injected <see cref="HttpClient"/> for making API requests.</param>
    /// <param name="settings">Typed configuration containing the API key and base URL.</param>
    public class OmdbMovieQueryService(HttpClient httpClient, IOptions<OmdbQuerySettings> settings) : IOmdbQueryService
    {
        private const string _defaultSearchType = "movie";
        private readonly HttpClient _httpClient = httpClient;
        private readonly OmdbQuerySettings _settings = settings.Value;

        /// <summary>
        /// Queries the OMDb API using a title keyword, optional release year, and page number.
        /// </summary>
        /// <param name="query">The movie title or keyword to search for.</param>
        /// <param name="year">Optional year filter to narrow the search results.</param>
        /// <param name="page">The page number of results to retrieve. Defaults to 1.</param>
        /// <returns>
        /// A wrapped result containing either a list of matching movies or an error message indicating why the query failed.
        /// </returns>
        public async Task<OmdbQueryServiceResult<List<OmdbMovieQueryResult>>> SearchAsync(string query,  int? year = null, int page = 1)
        {
            OmdbQueryResponse? response;
            var url = $"{_settings.BaseUrl}?apikey={_settings.ApiKey}&s={query}&type={_defaultSearchType}&page={page}";
            var result = new OmdbQueryServiceResult<List<OmdbMovieQueryResult>> { Data = [] };
            try
            {
                if (year.HasValue)
                {
                    url += $"&y={year.Value}";
                }

                response = await _httpClient.GetFromJsonAsync<OmdbQueryResponse>(url);
                if (response?.Error != null)
                {
                    result.ErrorMessage = response.Error;
                }
                else
                {
                    result.Data = response?.Search;
                }
            }
            catch (HttpRequestException)
            {
                result.ErrorMessage = "There was a problem reaching the movie database. Please try again later.";
            }
            catch (NotSupportedException)
            {
                result.ErrorMessage = "We received an unexpected response from the movie database.";
            }

            return result;
        }
    }
}
