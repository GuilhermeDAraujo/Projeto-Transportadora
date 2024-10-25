using Microsoft.AspNetCore.Mvc;
using Projeto_Transportadora.Models;
using Projeto_Transportadora.Services;

namespace Projeto_Transportadora.Controllers
{
    public class CaminhaoController : Controller
    {
        private readonly ICaminhaoServices _caminhaoServices;

        public CaminhaoController(ICaminhaoServices caminhaoServices)
        {
            _caminhaoServices = caminhaoServices;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _caminhaoServices.ListarTodosCaminhoesAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Caminhao caminhao)
        {
            if (ModelState.IsValid)
            {
                if (await _caminhaoServices.CaminhaoJaCadastrado(caminhao.Placa))
                {
                    ModelState.AddModelError("", "Caminhão já cadastrado!");
                    return View(caminhao);
                }
                await _caminhaoServices.CreateAsync(caminhao);
                return RedirectToAction(nameof(Index));
            }
            return View(caminhao);
        }

        public async Task<IActionResult> Update(int id)
        {
            var caminhao = await _caminhaoServices.BuscarCaminhao(id);
            if (caminhao == null)
            {
                ModelState.AddModelError("", "Caminhão não encontrado");
                return RedirectToAction(nameof(Index));
            }
            return View(caminhao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Caminhao caminhao)
        {
            if (ModelState.IsValid)
            {
                if (await _caminhaoServices.CaminhaoJaCadastrado(caminhao.Placa))
                {
                    ModelState.AddModelError("", "Caminhão já cadastrado!");
                    return View(caminhao);
                }
                await _caminhaoServices.UpdateAsync(caminhao);
                return RedirectToAction(nameof(Index));
            }
            return View(caminhao);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var caminhao = await _caminhaoServices.BuscarCaminhao(id);
            if (caminhao == null)
            {
                ModelState.AddModelError("", "Caminhão não encontrado");
                return RedirectToAction(nameof(Index));
            }
            return View(caminhao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Caminhao caminhao)
        {
            await _caminhaoServices.DeleteAsync(caminhao);
            return RedirectToAction(nameof(Index));
        }
    }
}