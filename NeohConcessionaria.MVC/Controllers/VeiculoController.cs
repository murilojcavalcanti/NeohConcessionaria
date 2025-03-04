﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NeohConcessionaria.Core.Entities;
using NeohConcessionaria.Core.Enum;
using NeohConcessionaria.Infra.Repositories.Veiculos;
using NeohConcessionaria.Infrastructure.Repositories.Fabricantes;
using NeohConcessionaria.MVC.Models.VeiculoModels;
using System.Linq.Expressions;

namespace NeohConcessionaria.MVC.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly IVeiculoRepository _VeiculoRepository;
        private readonly IFabricanteRepository _FabricanteRepository;

        public VeiculoController(IVeiculoRepository veiculoRepository, IFabricanteRepository fabricanteRepository)
        {
            _VeiculoRepository = veiculoRepository;
            _FabricanteRepository = fabricanteRepository;
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.TiposVeiculo = Enum.GetValues(typeof(EnumTipoVeiculo))
                              .Cast<EnumTipoVeiculo>()
                              .Select(e => new SelectListItem
                              {
                                  Value = ((int)e).ToString(),
                                  Text = e.ToString()
                              })
                              .ToList();
            ViewBag.Fabricantes = new SelectList(await _FabricanteRepository.GetAll(), "FabricanteId","Nome");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Veiculo veiculo)
        {

            if (veiculo.AnoFabricacao > DateTime.Now.Year)
            {
                ModelState.AddModelError("AnoFabricacao", "O Ano de Fabricação não pode ser maior que o ano atual ou menor que 1800.");
                return View(veiculo);
            }
            
            try
            {
                var created = await _VeiculoRepository.Create(veiculo);
                TempData["MessagemSucesso"] = "Veiculo inserido Com sucesso!";
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar fabricante: {ex}");
                TempData["MensagemErro"] = "Ocorreu um erro ao inserir o veículo.  Por favor, tente novamente.";
                ViewBag.Fabricantes = new SelectList(await _FabricanteRepository.GetAll(), "FabricanteId", "Nome");
                return View(veiculo);
            }
        }

        public async Task<IActionResult> List()
        {
            VeiculoViewModel veiculosVM = new()
            {
                Veiculos = await _VeiculoRepository.GetAll()
            };
            return View(veiculosVM);
        }
        public async Task<IActionResult> Update(int VeiculoId)
        {
            ViewBag.Fabricantes = new SelectList(await _FabricanteRepository.GetAll(), "FabricanteId", "Nome");
            Veiculo Veiculo  = await _VeiculoRepository.Get(v => v.VeiculoId == VeiculoId);
            return View(Veiculo);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Veiculo Veiculo)
        {

            try
            {
                _VeiculoRepository.Update(Veiculo);
                TempData["MessagemSucesso"] = "Veiculo atualizado Com sucesso!";
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar Veiculo: {ex}");
                TempData["MensagemErro"] = "Ocorreu um erro ao atualizar o Veiculo.  Por favor, tente novamente.";
                return View(Veiculo);

            }
        }

        public async Task<IActionResult> Delete(int VeiculoId)
        {
            Veiculo Veiculo = await _VeiculoRepository.Get(v => v.VeiculoId== VeiculoId);
            _VeiculoRepository.Delete(Veiculo);
            TempData["MessagemSucesso"] = "Veiculo Excluido Com sucesso!";
            return RedirectToAction(nameof(List));
        }
    }
}
