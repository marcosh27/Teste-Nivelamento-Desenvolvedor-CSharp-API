namespace Questao5.Application.DTOs
{
    public class MovimentacaoRequestDto
    {
        public Guid IdRequisicao { get; set; }
        public string IdContaCorrente { get; set; }
        public decimal Valor { get; set; }
        public string TipoMovimento { get; set; } // 'C' ou 'D'
    }
}
