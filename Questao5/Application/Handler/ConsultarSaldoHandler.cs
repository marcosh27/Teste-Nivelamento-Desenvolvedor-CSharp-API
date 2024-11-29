using MediatR;
using Questao5.Application.Command;
using Questao5.Application.DTOs;
using Questao5.Application.Interfaces;

namespace Questao5.Application.Handler
{
    public class ConsultarSaldoHandler: IRequestHandler<ConsultarSaldoCommand, SaldoResponseDto>
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public ConsultarSaldoHandler(IContaCorrenteRepository contaCorrenteRepository, IMovimentacaoRepository movimentacaoRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public async Task<SaldoResponseDto> Handle(ConsultarSaldoCommand request, CancellationToken cancellationToken)
        {
            // Validação de conta existente
            var conta = await _contaCorrenteRepository.GetByIdAsync(request.IdContaCorrente);
            if (conta == null) throw new Exception("Tipo: INVALID_ACCOUNT");

            // Validação de conta ativa
            if (!conta.Ativo) throw new Exception("Tipo: INACTIVE_ACCOUNT");

            // Cálculo do saldo atual
            var movimentos = await _movimentacaoRepository.GetMovimentosByContaAsync(request.IdContaCorrente);
            decimal somaCreditos = 0;
            decimal somaDebitos = 0;

            foreach (var movimento in movimentos)
            {
                if (movimento.TipoMovimento == "C")
                    somaCreditos += movimento.Valor;
                else if (movimento.TipoMovimento == "D")
                    somaDebitos += movimento.Valor;
            }

            var saldoAtual = somaCreditos - somaDebitos;

            return new SaldoResponseDto
            {
                NumeroContaCorrente = conta.Numero,
                NomeTitular = conta.Nome,
                DataHoraResposta = DateTime.Now,
                SaldoAtual = saldoAtual
            };
        }
    }
}