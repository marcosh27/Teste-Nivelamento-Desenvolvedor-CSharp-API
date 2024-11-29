namespace Questao5.Domain.Entities;

public class Movimentacao
{
    public string IdMovimento { get; set; }
    public string IdContaCorrente { get; set; }
    public DateTime DataMovimento { get; set; }
    public string TipoMovimento { get; set; } // 'C' ou 'D'
    public decimal Valor { get; set; }
}