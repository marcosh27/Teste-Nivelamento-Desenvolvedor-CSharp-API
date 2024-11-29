using MediatR;
using Questao5.Application.Command;
using Questao5.Application.Interfaces;
using Questao5.Domain.Entities;
using Questao5.Domain.Exceptions;

namespace Questao5.Application.Handler
{
    public class MovimentarContaHandler : IRequestHandler<MovimentarContaCommand, string>
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public MovimentarContaHandler(IMovimentacaoRepository movimentacaoRepository, IContaCorrenteRepository contaCorrenteRepository)
        {
            _movimentacaoRepository = movimentacaoRepository;
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public async Task<string> Handle(MovimentarContaCommand request, CancellationToken cancellationToken)
        {
            // Validação de conta existente e ativa
            var conta = await _contaCorrenteRepository.GetByIdAsync(request.IdContaCorrente);
            if (conta == null) throw new Exception("Tipo: INVALID_ACCOUNT");
            if (!conta.Ativo) throw new Exception("Tipo: INACTIVE_ACCOUNT");

            // Validação de valor
            if (request.Valor <= 0) throw new Exception("Tipo: INVALID_VALUE");

            // Validação de tipo de movimento
            if (request.TipoMovimento != "C" && request.TipoMovimento != "D") throw new Exception("Tipo: INVALID_TYPE");

            // Criação do movimento
            var movimento = new Movimentacao
            {
                IdMovimento = Guid.NewGuid().ToString(),
                IdContaCorrente = request.IdContaCorrente,
                DataMovimento = DateTime.Now,
                TipoMovimento = request.TipoMovimento,
                Valor = request.Valor
            };

            await _movimentacaoRepository.AddMovimentoAsync(movimento);

            return movimento.IdMovimento;
        }
    }
}

