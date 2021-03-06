using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using VideoRental.Web.Models.DTO;

namespace VideoRental.Web.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly HttpClient _apiClient;
        IConfiguration _configuration;

        public FilmeService(HttpClient apiClient, IConfiguration configuration)
        {
            _apiClient = apiClient;
            _configuration = configuration;
    }

        public async Task Create(FilmeDTO filme)
        {           
            var uri = Convert.ToString(_configuration.GetValue<string>("API:Url"));
            var rentContent = new StringContent(JsonConvert.SerializeObject(filme),
                                   System.Text.Encoding.UTF8, "application/json");
            var response = await _apiClient.PostAsync(uri, rentContent);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {            
            var uri = Convert.ToString(_configuration.GetValue<string>("API:Url"));
            var response = _apiClient.DeleteAsync(string.Format(uri + "/{0}", id));            
            var result = response.Result;
            result.EnsureSuccessStatusCode();
        }

        public async Task<List<FilmeDTO>> GetAll()
        {                       
            var uri = Convert.ToString(_configuration.GetValue<string>("API:Url"));

            var response = _apiClient.GetAsync(uri);                       
            var result = response.Result;
            if (!result.IsSuccessStatusCode)
            {
                
            }
            var resultado = await result.Content.ReadAsAsync<List<FilmeDTO>>();
            return resultado;
        }

        public async Task<List<FilmeDTO>> GetByGenero(string genero)
        {            
            var uri = Convert.ToString(_configuration.GetValue<string>("API:Url"));
            var response = _apiClient.GetAsync(string.Format(uri + "/genero/{0}", genero));
            var result = response.Result;
            if (!result.IsSuccessStatusCode)
            {

            }
            var resultado = await result.Content.ReadAsAsync<List<FilmeDTO>>();
            return resultado;
        }

        public async Task<FilmeDTO> GetById(int id)
        {            
            var uri = Convert.ToString(_configuration.GetValue<string>("API:Url"));
            var response = _apiClient.GetAsync(string.Format(uri + "/id/{0}", id));
            var result = response.Result;
            if (!result.IsSuccessStatusCode)
            {

            }
            var resultado = await result.Content.ReadAsAsync<FilmeDTO>();
            return resultado;
        }

        public async Task<List<FilmeDTO>> GetByName(string name)
        {            
            var uri = Convert.ToString(_configuration.GetValue<string>("API:Url"));
            var response = _apiClient.GetAsync(string.Format(uri+"/name/{0}",name));
            var result = response.Result;
            if (!result.IsSuccessStatusCode)
            {

            }
            var resultado = await result.Content.ReadAsAsync<List<FilmeDTO>>();
            return resultado;
        }

        public async Task Update(FilmeDTO filme)
        {            
            var uri = Convert.ToString(_configuration.GetValue<string>("API:Url"));
            var rentContent = new StringContent(JsonConvert.SerializeObject(filme),
                                   System.Text.Encoding.UTF8, "application/json");            
            var response = await _apiClient.PatchAsync(uri, rentContent);            
            response.EnsureSuccessStatusCode();
        }
    }
}
