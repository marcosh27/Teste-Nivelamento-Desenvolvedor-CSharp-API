using MediatR;

namespace Questao5.Application.Command
{
    public class MovimentarContaCommand : IRequest<string>
    {
        public Guid IdRequisicao { get; set; }
        public string IdContaCorrente { get; set; }
        public decimal Valor { get; set; }
        public string TipoMovimento { get; set; } // 'C' ou 'D'
    }
}