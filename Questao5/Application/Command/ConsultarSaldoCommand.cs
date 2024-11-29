using MediatR;
using Questao5.Application.DTOs;

namespace Questao5.Application.Command
{
    public class ConsultarSaldoCommand : IRequest<SaldoResponseDto>
    {
        public string IdContaCorrente { get; set; }
    }
}