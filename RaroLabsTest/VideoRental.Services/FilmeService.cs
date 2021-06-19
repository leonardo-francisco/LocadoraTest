using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Domain.Entities;
using VideoRental.Domain.Interface;
using VideoRental.Services.Interface;

namespace VideoRental.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<int> CreateMoviesAsync(Filme movie)
        {
            return await _filmeRepository.CreateAsync(movie);
        }

        public async Task<int> DeleteMoviesAsync(Filme movie)
        {
            return await _filmeRepository.DeleteAsync(movie);
        }

        public async Task<List<Filme>> GetAllMovies()
        {
            return await _filmeRepository.GetAllAsync();
        }

        public async Task<List<Filme>> GetMoviesByGenero(string gnr)
        {
            return await _filmeRepository.GetByGeneroAsync(gnr);
        }

        public async Task<Filme> GetMoviesById(int id)
        {
            return await _filmeRepository.GetByIdAsync(id);
        }

        public async Task<List<Filme>> GetMoviesByName(string name)
        {
            return await _filmeRepository.GetByNameAsync(name);
        }

        public async Task<int> UpdateMoviesAsync(Filme movie)
        {
            return await _filmeRepository.UpdateAsync(movie);
        }
    }
}
