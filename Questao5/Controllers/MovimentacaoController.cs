using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Command;
using Questao5.Application.DTOs;
using Questao5.Domain.Exceptions;

namespace Questao5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimentacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovimentacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> MovimentarConta([FromBody] MovimentacaoRequestDto request)
        {
            var command = new MovimentarContaCommand
            {
                IdRequisicao = request.IdRequisicao,
                IdContaCorrente = request.IdContaCorrente,
                Valor = request.Valor,
                TipoMovimento = request.TipoMovimento
            };

            var idMovimento = await _mediator.Send(command);
            return Ok(new { IdMovimento = idMovimento });
        }
        [HttpPost("consultar-saldo")]
        public async Task<IActionResult> ConsultarSaldo([FromBody] string idContaCorrente)
        {
            try
            {
                var command = new ConsultarSaldoCommand { IdContaCorrente = idContaCorrente };
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }
    }
}