using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Domain.Entities;

namespace VideoRental.Services.Interface
{
    public interface IFilmeService
    {
        public Task<List<Filme>> GetAllMovies();
        public Task<Filme> GetMoviesById(int id);
        public Task<List<Filme>> GetMoviesByName(string name);
        public Task<List<Filme>> GetMoviesByGenero(string gnr);
        public Task<int> CreateMoviesAsync(Filme movie);
        public Task<int> UpdateMoviesAsync(Filme movie);
        public Task<int> DeleteMoviesAsync(Filme movie);
    }
}
