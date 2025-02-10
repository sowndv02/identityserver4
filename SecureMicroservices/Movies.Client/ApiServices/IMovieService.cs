using Movies.Client.Models;

namespace Movies.Client.ApiServices
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovie(string id);
        Task<Movie> CreateMovie(Movie movie);
        Task<Movie> UpdateMovie(Movie movie);
        Task DeleteMovie(string id);
        Task<UserInfoViewModel> GetUserInfo();
    }
}
