using Microsoft.AspNetCore.Mvc;
using NeohConcessionaria.Application.Services.FabricanteServices;
using NeohConcessionaria.Core.Entities;
using NeohConcessionaria.Infrastructure.Repositories.Fabricantes;
using NeohConcessionaria.MVC.Models.FabricanteModels;

namespace NeohConcessionaria.MVC.Controllers
{
    public class FabricanteController : Controller
    {
        private readonly IFabricanteRepository _fabricanteRepository;
        private readonly IFabricanteService _fabricanteService;

        public FabricanteController(IFabricanteRepository fabricanteRepository, IFabricanteService fabricanteService)
        {
            _fabricanteRepository = fabricanteRepository;
            _fabricanteService = fabricanteService;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Fabricante fabricante)
        {
            if(fabricante.AnoFundacao>= DateTime.Now.Year||fabricante.AnoFundacao<1800)
            {
                ModelState.AddModelError("AnoFundacao", "O Ano de Fundação não pode ser maior que o ano atual ou menor que 1800.");
                return View(fabricante);
            }
            
            try
            {
                await _fabricanteService.Create(fabricante);
                TempData["MessagemSucesso"] = "Fabricante Criado Com sucesso!";
                return RedirectToAction(nameof(List));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar fabricante: {ex}");
                TempData["MensagemErro"] = "Ocorreu um erro ao criar o fabricante.  Por favor, tente novamente.";
                return View(fabricante);

            }
        }
        public async Task<IActionResult> List()
        {
            List<Fabricante> Fabricantes = await _fabricanteService.List();
            FabricanteViewModel fabricanteVm = new()
            {
                Fabricantes = Fabricantes
            };
            return View(fabricanteVm);
        }

        public async Task<IActionResult> Update(int FabricanteId)
        {
            Fabricante Fabricante = await _fabricanteService.Details(FabricanteId);
            return View(Fabricante);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Fabricante Fabricante)
        {

            try
            {
                _fabricanteService.Update(Fabricante);
                TempData["MessagemSucesso"] = "Fabricante atualizado Com sucesso!";
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar Fabricante: {ex}");
                TempData["MensagemErro"] = "Ocorreu um erro ao atualizar o Fabricante.  Por favor, tente novamente.";
                return View(Fabricante);

            }
        }

        public async Task<IActionResult> Delete(int FabricanteId)
        {
            _fabricanteService.Delete(FabricanteId);
            TempData["MessagemSucesso"] = "Fabricante Excluido Com sucesso!";
            return RedirectToAction(nameof(List));
        }
    }
}
