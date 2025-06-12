# OMDb Movie Search App

A simple ASP.NET Razor Pages web app, developed in around 2 hours, which queries the OMDb API for movie information, using title and optional release year.

## Tech Stack

- ASP.NET Core (Razor Pages)
- C#
- OMDb API
- Bootstrap (for basic styling)
- Dependency Injection & Configuration Binding
- Model Binding & Validation
- HttpClient + JSON deserialization

## Features Implemented (within 2-hour limit)

- Title and year-based search form
- Data binding to Razor PageModel
- OMDb API integration via injected service
- Basic error handling and validation
- Responsive grid-based layout using Bootstrap
- Display of movie titles and release years

## Time Limit Acknowledgement

This project was completed in just over 2 hours. The core functionality was implemented within the limit, but additional polish and enhancements were added slightly beyond it to improve usability and robustness (mostly pertaining to validation).

## If I Had More Time

Given more time, I would have:

- Added pagination support to navigate through result pages
- Added a further form field for a given IMDB movie ID and associated search handling
- Implemented a more structured search result component (e.g. cards with posters, if available, and further movie details such as synposes and cast details)
- Replaced full-page reload with AJAX for better UX
- Cached results per query to reduce redundant API calls
- Added unit tests for the query service and PageModel
- Added sorting or filtering options (e.g., by year or title)
- Added more comprehensive commenting within the codebase

## Usage

You’ll need an OMDb API key to run this project. Set it in `appsettings.json`:

```json
"Omdb": {
  "BaseUrl": "https://www.omdbapi.com/",
  "ApiKey": "API_KEY_GOES_HERE"
}