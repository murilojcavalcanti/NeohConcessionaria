using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NeohConcessionaria.Core.Entities;
using NeohConcessionaria.Core.Enum;
using NeohConcessionaria.Infra.Repositories.Concessionarias;
using NeohConcessionaria.Infra.Repositories.Veiculos;
using NeohConcessionaria.Infra.Repositories.Vendas;
using NeohConcessionaria.Infrastructure.Repositories.Fabricantes;
using NeohConcessionaria.MVC.Models;
using NeohConcessionaria.MVC.Models.ClienteModels;
using NeohConcessionaria.MVC.Models.VeiculoModels;
using NeohConcessionaria.MVC.Models.VendaModels;

namespace NeohConcessionaria.MVC.Controllers
{
    public class VendaController : Controller
    {
        private readonly IVeiculoRepository _VeiculoRepository;
        private readonly IClienteRepository _ClienteRepository;
        private readonly IFabricanteRepository _FabricanteRepository;
        private readonly IConcessionariaRepository _ConcessionariaRepository;
        private readonly IVendaRepository _VendaRepository;

        public VendaController(IVeiculoRepository veiculoRepository, IFabricanteRepository fabricanteRepository, 
            IConcessionariaRepository concessionariaRepository, IVendaRepository vendaRepository, IClienteRepository clienteRepository)
        {
            _VeiculoRepository = veiculoRepository;
            _FabricanteRepository = fabricanteRepository;
            _ConcessionariaRepository = concessionariaRepository;
            _VendaRepository = vendaRepository;
            _ClienteRepository = clienteRepository;
        }
        public async Task<IActionResult> Create()
        {
            
            ViewBag.Fabricantes = await _FabricanteRepository.GetAll();
            ViewBag.Concessionarias = new SelectList(await _ConcessionariaRepository.GetAll(), "ConcessionariaId", "Nome");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VendaInputModel vendaInputModel)
        {
            Venda venda = vendaInputModel.Venda;
            Cliente cliente = vendaInputModel.Cliente;
            Veiculo veiculo = await  _VeiculoRepository.Get(v => v.VeiculoId == venda.VeiculoId);
            venda.ProtocoloVenda = Guid.NewGuid().ToString().Substring(0,20); 
            
            if (venda.PrecoVenda > veiculo.Preco)
            {
                ModelState.AddModelError("PrecoVenda", "Valor de venda maior que o valor do veiculo");
                return View(vendaInputModel);
            }
            if (venda.DataVenda>DateTime.Now )
            {
                ModelState.AddModelError("DataVenda", "Data de venda deve ser no passado.");
                return View(vendaInputModel);
            }

            try
            {
                await _ClienteRepository.Create(cliente);
                venda.ClienteId = cliente.ClienteId;
                await _VendaRepository.Create(venda);
                TempData["MessagemSucesso"] = "Venda inserida Com sucesso!";
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar fabricante: {ex}");
                TempData["MensagemErro"] = "Ocorreu um erro ao inserir o veículo.  Por favor, tente novamente.";
                ViewBag.Fabricantes = await _FabricanteRepository.GetAll();
                ViewBag.Concessionarias = new SelectList(await _ConcessionariaRepository.GetAll(), "ConcessionariaId", "Nome");
                return View(vendaInputModel);
            }
        }

        public async Task<IActionResult> Delete(int VendaId)
        {
            Venda Venda = await _VendaRepository.Get(v => v.VendaId == VendaId);
            _VendaRepository.Delete(Venda);
            TempData["MessagemSucesso"] = "Venda Excluida Com sucesso!";
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> List()
        {
            List<Venda> vendas = await _VendaRepository.GetAll();
            VendaViewModel VendasVM = new()
            {
                Vendas = vendas.Select(v =>VendaModel.FomEntity(v)).ToList()
            };
            return View(VendasVM);
        }
        public async Task<IActionResult> ListVeiculosPorFabricante(int fabricanteId)
        {
            List<Veiculo> veiculos = await _VeiculoRepository.GetPorFabricante(fabricanteId);

            return Json(veiculos.Select(v => new
            {
                veiculoId = v.VeiculoId,
                modelo = v.Modelo,
            }));
        }
    }
}

