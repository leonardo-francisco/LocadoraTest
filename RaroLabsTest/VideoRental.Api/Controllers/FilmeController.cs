using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoRental.Domain.Entities;
using VideoRental.Services.Interface;

namespace VideoRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _videoService;

        public FilmeController(IFilmeService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet]
        public async Task<ActionResult<Filme>> Get()
        {
            return Ok(await _videoService.GetAllMovies());
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<Filme>> GetById(int id)
        {
            Filme vd = new Filme();
            vd = await _videoService.GetMoviesById(id);
            return Ok(vd);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<Filme>> GetByName(string name)
        {
            List<Filme> vd = new List<Filme>();
            vd = await _videoService.GetMoviesByName(name);
            return Ok(vd.ToList());
        }

        [HttpGet("genero/{genero}")]
        public async Task<ActionResult<Filme>> GetByGenero(string genero)
        {
            List<Filme> vd = new List<Filme>();
            vd = await _videoService.GetMoviesByGenero(genero);
            return Ok(vd);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Filme vd)
        {
            await _videoService.CreateMoviesAsync(vd);

            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] Filme vd)
        {
            await _videoService.UpdateMoviesAsync(vd);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            Filme vd = new Filme();
            vd = await _videoService.GetMoviesById(id);
            await _videoService.DeleteMoviesAsync(vd);
            
        }
    }
}