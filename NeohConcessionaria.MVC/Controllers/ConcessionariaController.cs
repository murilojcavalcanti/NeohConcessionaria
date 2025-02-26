using Microsoft.AspNetCore.Mvc;
using NeohConcessionaria.Core.Entities;
using NeohConcessionaria.Infra.Repositories.Concessionarias;
using NeohConcessionaria.MVC.Models.ConcessionariaModels;

namespace NeohConcessionaria.MVC.Controllers
{
    public class ConcessionariaController : Controller
    {
        private readonly IConcessionariaRepository _ConcessionariaRepository;

        public ConcessionariaController(IConcessionariaRepository ConcessionariaRepository)
        {
            _ConcessionariaRepository = ConcessionariaRepository;
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
                await _ConcessionariaRepository.Create(Concessionaria);
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
            List<Concessionaria> Concessionarias = await _ConcessionariaRepository.GetAll();
            ConcessionariaViewModel ConcessionariaVm = new()
            {
                Concessionarias = Concessionarias
            };
            return View(ConcessionariaVm);
        }
        public async Task<IActionResult> Details(int ConcessionariaId)
        {
            Concessionaria concessionaria = await _ConcessionariaRepository.Get(c => c.ConcessionariaId == ConcessionariaId);

            return View(concessionaria);
        }

        public async Task<IActionResult> Update(int ConcessionariaId)
        {
            Concessionaria Concessionaria = await _ConcessionariaRepository.Get(f => f.ConcessionariaId == ConcessionariaId);
            return View(Concessionaria);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Concessionaria Concessionaria)
        {

            try
            {
                _ConcessionariaRepository.Update(Concessionaria);
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
            Concessionaria Concessionaria = await _ConcessionariaRepository.Get(f => f.ConcessionariaId == ConcessionariaId);
            _ConcessionariaRepository.Delete(Concessionaria);
            TempData["MessagemSucesso"] = "Concessionaria Excluido Com sucesso!";
            return RedirectToAction(nameof(List));
        }
    }
}
