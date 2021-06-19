using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VideoRental.Web.Models.DTO;

namespace VideoRental.Web.Services
{
    public interface IFilmeService
    {
        Task<List<FilmeDTO>> GetAll();
        Task<FilmeDTO> GetById(int id);
        Task<List<FilmeDTO>> GetByName(string name);
        Task<List<FilmeDTO>> GetByGenero(string genero);
        Task Create(FilmeDTO filme);
        Task Update(FilmeDTO filme);
        Task Delete(int id);
    }
}
