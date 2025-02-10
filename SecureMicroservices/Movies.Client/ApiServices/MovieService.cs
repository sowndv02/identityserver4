﻿using Movies.Client.Models;

namespace Movies.Client.ApiServices
{
    public class MovieService : IMovieService
    {
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
            var movieList = new List<Movie>();
            movieList.Add(new Movie() 
            {
                Id = 1,
                Genre = "Comics",
                Title  = "ads",
                Rating = "9.2",
                ImageUrl = "images/src",
                ReleaseDate = DateTime.Now,
                Owner = "swn"
            });
            return await Task.FromResult(movieList);
        }

        public Task<Movie> UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
