using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BancoDigital.Models;
using BancoDigital.Services;
using BancoDigital.Models.DTO;

namespace BancoDigital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
       
        private readonly IOperacoesContaService _service;

        public ContasController( IOperacoesContaService service)
        {
            
            _service = service;
        }

        /// <summary>
        /// Obter saldo de uma determinada conta
        /// </summary>
        /// <param name="conta"></param>
        [HttpGet("Saldo")]
        public async Task<ActionResult> Saldo(string conta)
        {

            var existeConta = _service.ContaExistente(conta);

            if (existeConta)
            {
                var saldo = await _service.Saldo(conta);


                return Ok("saldo: " + saldo );
            }
            return BadRequest();
        }

        /// <summary>
        /// Efetuar Deposito de valor na conta do usuário.
        /// </summary>
        /// <param name="conta"></param>
        /// <returns code="200">Saldo da Conta Atual</returns>
        /// <returns code="404">Conta não existe.</returns>
        [HttpPut("Depositar")]
        public async Task<ActionResult<Conta>> Depositar([FromBody] EntradaContaDTO conta)
        {

            var contaAtualizada = await _service.Depositar(conta);
            if (contaAtualizada != null)
            {
                return Ok(contaAtualizada);
            }

            return NotFound();
        }

        /// <summary>
        /// Sacar / Debitar valor da conta.
        /// </summary>
        /// <param name="conta"></param>
        [HttpPut("Sacar")]
        public async Task<ActionResult<Conta>> Sacar([FromBody] EntradaContaDTO conta)
        {

            var saldo = await _service.Saldo(conta.Conta);
          
            if (saldo >= conta.Saldo)
            {

                var contaAtualizada = await _service.Sacar(conta);
                return Ok(contaAtualizada);
            }
            return UnprocessableEntity("Saldo Insuficiente");

            
        }




      



       



       
    }
}
