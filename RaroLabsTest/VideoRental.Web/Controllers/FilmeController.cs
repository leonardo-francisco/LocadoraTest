using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VideoRental.Web.Models.DTO;
using VideoRental.Web.Services;

namespace VideoRental.Web.Controllers
{
    public class FilmeController : Controller
    {
        private readonly IFilmeService _filmeService;
        private readonly IGeneroService _generoService;

        public FilmeController(IFilmeService filmeService, IGeneroService generoService)
        {
            _filmeService = filmeService;
            _generoService = generoService;
        }

        public async void PreencheDropDown()
        {
            ViewBag.gen = new SelectList(await _generoService.GetAll(), "Id", "Nome");

        }

        public async Task<IActionResult> Index(string searchName, string searchGender)
        {
            List<FilmeDTO> mv = new List<FilmeDTO>();

            if (!String.IsNullOrEmpty(searchName))
            {
                mv = await _filmeService.GetByName(searchName);
                return View(mv);
            }

            if (!String.IsNullOrEmpty(searchGender))
            {
                mv = await _filmeService.GetByGenero(searchGender);
                return View(mv);
            }

            mv = await _filmeService.GetAll();
            return View(mv);
        }

        public async Task<IActionResult> CadastrarFilme()
        {
            PreencheDropDown();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarFilme(FilmeDTO fdt)
        {
            PreencheDropDown();
            await _filmeService.Create(fdt);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditarFilme(int id)
        {
            PreencheDropDown();
            return View(await _filmeService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditarFilme(FilmeDTO fdt)
        {
            PreencheDropDown();
            await _filmeService.Update(fdt);
            return RedirectToAction(nameof(Index));
            
        }

        [HttpDelete]
        public async void Deletar(int id)
        {                        
            await _filmeService.Delete(id);
            
        }
    }
}