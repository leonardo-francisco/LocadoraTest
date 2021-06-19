using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VideoRental.Web.Models.DTO;

namespace VideoRental.Web.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly HttpClient _apiClient;

        public GeneroService(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<GeneroDTO>> GetAll()
        {
            var uri = "https://localhost:44353/api/Genero";

            var response = _apiClient.GetAsync(uri);
            var result = response.Result;
            if (!result.IsSuccessStatusCode)
            {

            }
            var resultado = await result.Content.ReadAsAsync<List<GeneroDTO>>();
            return resultado;
        }
    }
}
