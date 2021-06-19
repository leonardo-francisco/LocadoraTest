using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Domain.Entities;

namespace VideoRental.Services.Interface
{
    public interface IGeneroService
    {
        public Task<List<Genero>> GetAllGender();
        public Task<Genero> GetGenderById(int id);
        public Task<int> CreateGenderAsync(Genero gender);
        public Task<int> UpdateGenderAsync(Genero gender);
        public Task<int> DeleteGenderAsync(Genero gender);
    }
}
