using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Projeto_Transportadora.Models;
using Projeto_Transportadora.Services;
using Projeto_Transportadora.ViewModel;

namespace Projeto_Transportadora.Controllers
{
    public class NotaFiscalController : Controller
    {
        private readonly INotaFiscalServices _notaFiscalServices;
        private readonly IEstoqueService _estoqueServices;

        public NotaFiscalController(INotaFiscalServices notaFiscalServices, IEstoqueService estoqueService)
        {
            _notaFiscalServices = notaFiscalServices;
            _estoqueServices = estoqueService;
        }

        public IActionResult Menu()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            await CarregarViewBag();
            await CarregarViewBagCaminhao();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NotaFiscalEstoqueViewModel notaFiscal)
        {
            if(!ModelState.IsValid)
            {
                await CarregarViewBag();
                await CarregarViewBagCaminhao();
                return View(notaFiscal);
            }

            var notaFiscalEntrada = new NotaFiscal
            {
                NumeroNotaFiscal = notaFiscal.NumeroNotaFiscal,
                NomeCliente = notaFiscal.NomeCliente,
                EnderecoFaturado = notaFiscal.EnderecoFaturado,
                DataDoFaturamento = notaFiscal.DataDoFaturamento,
                NumeroDaCarga = notaFiscal.NumeroDaCarga,
                CaminhaoId = notaFiscal.CaminhaoId
            };

            var notaFiscalCriada = await _notaFiscalServices.CreateAsync(notaFiscalEntrada);
            await _estoqueServices.CreateAsync(notaFiscalCriada, notaFiscal.DataDaEntrada);

            await CarregarViewBag();
            return View();
        }


        public async Task CarregarViewBagCaminhao()
        {
            ViewBag.Caminhao = new SelectList(await _notaFiscalServices.ListarTodosCaminhoes(), "id","Placa");
        }

        public async Task CarregarViewBag()
        {
            ViewBag.NotasFiscais = await _estoqueServices.ObterNotasFiscaisDeHojeAsync();
        }
    }
}