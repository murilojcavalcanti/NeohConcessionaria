using Microsoft.AspNetCore.Mvc;
using NeohConcessionaria.Application.Services.ConcessionariaService;
using NeohConcessionaria.Core.Entities;
using NeohConcessionaria.Infra.Repositories.Concessionarias;
using NeohConcessionaria.MVC.Models.ConcessionariaModels;

namespace NeohConcessionaria.MVC.Controllers
{
    public class ConcessionariaController : Controller
    {
        private readonly IConcessionariaRepository _ConcessionariaRepository;
        private readonly IConcessionariaService _ConcessionariaService;
        public ConcessionariaController(IConcessionariaRepository ConcessionariaRepository, IConcessionariaService concessionariaService)
        {
            _ConcessionariaRepository = ConcessionariaRepository;
            _ConcessionariaService = concessionariaService;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Concessionaria Concessionaria)
        {
            
            try
            {
                await _ConcessionariaService.Create(Concessionaria);
                TempData["MessagemSucesso"] = "Concessionaria Criado Com sucesso!";
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar Concessionaria: {ex}");
                TempData["MensagemErro"] = "Ocorreu um erro ao criar o Concessionaria.  Por favor, tente novamente.";
                return View(Concessionaria);

            }
        }
        public async Task<IActionResult> List()
        {
            List<Concessionaria> Concessionarias = await _ConcessionariaService.List();
            ConcessionariaViewModel ConcessionariaVm = new()
            {
                Concessionarias = Concessionarias
            };
            return View(ConcessionariaVm);
        }
        public async Task<IActionResult> Details(int ConcessionariaId)
        {
            Concessionaria concessionaria = await _ConcessionariaService.Details(ConcessionariaId);

            return View(concessionaria);
        }

        public async Task<IActionResult> Update(int ConcessionariaId)
        {
            Concessionaria Concessionaria = await _ConcessionariaService.Details(ConcessionariaId);
            return View(Concessionaria);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Concessionaria Concessionaria)
        {

            try
            {
                _ConcessionariaService.Update(Concessionaria);
                TempData["MessagemSucesso"] = "Concessionaria atualizado Com sucesso!";
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar Concessionaria: {ex}");
                TempData["MensagemErro"] = "Ocorreu um erro ao atualizar o Concessionaria.  Por favor, tente novamente.";
                return View(Concessionaria);

            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int ConcessionariaId)
        {
            _ConcessionariaService.Delete(ConcessionariaId);
            TempData["MessagemSucesso"] = "Concessionaria Excluido Com sucesso!";
            return RedirectToAction(nameof(List));
        }
    }
}
