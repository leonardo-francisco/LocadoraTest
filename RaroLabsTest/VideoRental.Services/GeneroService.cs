using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Domain.Entities;
using VideoRental.Domain.Interface;
using VideoRental.Services.Interface;

namespace VideoRental.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroService(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        public async Task<int> CreateGenderAsync(Genero gender)
        {
            return await _generoRepository.CreateAsync(gender);
        }

        public async Task<int> DeleteGenderAsync(Genero gender)
        {
            return await _generoRepository.DeleteAsync(gender);
        }

        public async Task<List<Genero>> GetAllGender()
        {
            return await _generoRepository.GetAllAsync();
        }

        public async Task<Genero> GetGenderById(int id)
        {
            return await _generoRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateGenderAsync(Genero gender)
        {
            return await _generoRepository.UpdateAsync(gender);
        }
    }
}
