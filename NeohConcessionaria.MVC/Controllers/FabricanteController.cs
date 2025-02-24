using Microsoft.AspNetCore.Mvc;
using NeohConcessionaria.Core.Entities;
using NeohConcessionaria.Infrastructure.Repositories.Fabricantes;
using NeohConcessionaria.MVC.Models.FabricanteModels;

namespace NeohConcessionaria.MVC.Controllers
{
    public class FabricanteController : Controller
    {
        private readonly IFabricanteRepository _fabricanteRepository;

        public FabricanteController(IFabricanteRepository fabricanteRepository)
        {
            _fabricanteRepository = fabricanteRepository;
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
            if (!ModelState.IsValid)
            {
                return View(fabricante);
            }
            try
            {
                await _fabricanteRepository.Create(fabricante);
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

        public async Task<IActionResult> Delete(int FabricanteId)
        {
            Fabricante fabricante =await _fabricanteRepository.Get(f => f.FabricanteId == FabricanteId);
            _fabricanteRepository.Delete(fabricante);
            TempData["MessagemSucesso"] = "Fabricante Excluido Com sucesso!";
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> List()
        {
            List<Fabricante> Fabricantes = await _fabricanteRepository.GetAll();
            FabricanteViewModel fabricanteVm = new()
            {
                Fabricantes = Fabricantes
            };
            return View(fabricanteVm);
        }

    }
}
