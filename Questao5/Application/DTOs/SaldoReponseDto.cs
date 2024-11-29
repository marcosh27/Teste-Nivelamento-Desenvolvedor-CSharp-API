namespace Questao5.Application.DTOs
{
    public class SaldoResponseDto
    {
        public int NumeroContaCorrente { get; set; }
        public string NomeTitular { get; set; }
        public DateTime DataHoraResposta { get; set; }
        public decimal SaldoAtual { get; set; }
    }
}