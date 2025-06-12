using OmdbApp.Models;

namespace OmdbApp.Services
{
    /// <summary>
    /// Interface for querying movie data from the OMDb API.
    /// </summary>
    public interface IOmdbQueryService
    {
        /// <summary>
        /// Defines a contract for querying the OMDb API with a search term, optional year, and page number.
        /// </summary>
        /// <param name="query">The search keyword or movie title.</param>
        /// <param name="year">An optional release year to narrow results.</param>
        /// <param name="page">The results page to retrieve (default is 1).</param>
        /// <returns>A task that resolves to a result wrapper containing a list of matching movies or an error message.</returns>
        Task<OmdbQueryServiceResult<List<OmdbMovieQueryResult>>> SearchAsync(string query, int? year, int page = 1);
    }
}
