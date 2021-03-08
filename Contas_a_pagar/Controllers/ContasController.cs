
using Contas_a_pagar.Models;
using Contas_a_pagar.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Contas_a_pagar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContasController : ControllerBase
    {
        private readonly IContaService _contaService;

        public ContasController(IContaService contaService)
        {
            _contaService = contaService ?? throw new ArgumentNullException(nameof(contaService));
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_contaService.ListarContas());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Inserir(Conta conta)
        {
            try
            {
                _contaService.InserirConta(conta);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
