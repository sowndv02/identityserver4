using IdentityModel.Client;
using Movies.Client.Models;
using Newtonsoft.Json;

namespace Movies.Client.ApiServices
{
    public class MovieService : IMovieService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MovieService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public Task<Movie> CreateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovie(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovie(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            //WAY1
            var httpClient = _httpClientFactory.CreateClient("MovieAPIClient");

            var request = new HttpRequestMessage(HttpMethod.Get, "/api/movies");
            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            List<Movie> movieList = JsonConvert.DeserializeObject<List<Movie>>(content);
            return movieList;



            // WAY2
            //// 1- Get Token from identity server, of course we should provide the IS configurations like address client Id and client secret
            //// 2- Send request to protected API
            //// 3- Deserialize object to MovieList



            //// 1. "Retreive" our api credentials. This must be regitered on Identity Server
            //var apiClientCredentials = new ClientCredentialsTokenRequest
            //{
            //    Address = "https://localhost:5005/connect/token",
            //    ClientId = "movieClient",
            //    ClientSecret = "secret",

            //    // This is the scope our Protected API requires.
            //    Scope = "movieAPI"
            //};

            //// Create new HttpClient to talk to our IdentityServer (localhost:5005)
            //var client = new HttpClient();

            //// just check if we can reach the Discovery document. Not 100% needed but...
            //var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5005");
            //if (disco.IsError) return null; // throw 500 error

            ////2. Authenticates and get an access token from Identity Server
            //var tokenResponse = await client.RequestClientCredentialsTokenAsync(apiClientCredentials);
            //if (tokenResponse.IsError) return null;

            ////2- Send request to protected API

            //// Another HttpClient for talking now with our protected API
            //var apiClient = new HttpClient();

            ////3. set the access_token in the request authorization: Bearer <token>
            //apiClient.SetBearerToken(tokenResponse.AccessToken);


            //// 4. Send a request to our protected api

            //var response = await apiClient.GetAsync("https://localhost:5001/api/movies");

            //response.EnsureSuccessStatusCode();
            //var content = await response.Content.ReadAsStringAsync();

            //// Deserialize Object to Movie List
            //List<Movie> movieList = JsonConvert.DeserializeObject<List<Movie>>(content);
            //return movieList;

            //var movieList = new List<Movie>();
            //movieList.Add(new Movie() 
            //{
            //    Id = 1,
            //    Genre = "Comics",
            //    Title  = "ads",
            //    Rating = "9.2",
            //    ImageUrl = "images/src",
            //    ReleaseDate = DateTime.Now,
            //    Owner = "swn"
            //});
            //return await Task.FromResult(movieList);
        }

        public Task<Movie> UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
