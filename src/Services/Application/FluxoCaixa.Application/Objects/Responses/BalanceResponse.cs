namespace FluxoCaixa.Application.Objects.Responses;

public class BalanceResponse(DateTime date, decimal consolidateBalance, decimal negativeBalance, decimal totalBalance)
{
    public DateTime Date { get; set; } = date;
    public decimal ConsolidateBalance { get; set; } = consolidateBalance;
    public decimal NegativeBalance { get; set; } = negativeBalance;
    public decimal TotalBalance { get; set; } = totalBalance;
}
