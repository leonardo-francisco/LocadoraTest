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
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroService _generoService;
        public GeneroController(IGeneroService generoService)
        {
            _generoService = generoService;
        }

        [HttpGet]
        public async Task<ActionResult<Genero>> Get()
        {
            return Ok(await _generoService.GetAllGender());
        }

        [HttpGet("id")]
        public async Task<ActionResult<Genero>> GetById(int id)
        {
            Genero gn = new Genero();
            gn = await _generoService.GetGenderById(id);
            return Ok(gn);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Genero gn)
        {
            await _generoService.CreateGenderAsync(gn);

            return Ok(gn);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] Genero gn)
        {
            await _generoService.UpdateGenderAsync(gn);

            return Ok(gn);
        }

        [HttpDelete]
        public async void Delete(int id)
        {
            Genero gn = new Genero();
            gn = await _generoService.GetGenderById(id);
            await _generoService.DeleteGenderAsync(gn);

        }
    }
}