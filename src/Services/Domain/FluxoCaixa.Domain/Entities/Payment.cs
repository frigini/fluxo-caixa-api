using System.Text.RegularExpressions;
using FluxoCaixa.Core.DomainObjects;
using FluxoCaixa.Domain.Entities.Enums;

namespace FluxoCaixa.Domain.Entities;

public class Payment : Entity
{
    protected Payment() { }

    public Payment(
        string description, 
        DateTime paymentDate,
        int paymentType, 
        decimal paymentValue)
    {
        UpdateDescription(description);
        UpdatePaymentDate(paymentDate);
        UpdatePaymentType(paymentType);
        UpdatePaymentValue(paymentValue);
    }

    public string Description { get; private set; }
    public DateTime PaymentDate { get; private set; }
    public PaymentTypeEnum PaymentType { get; private set; }
    public decimal PaymentValue { get; private set; }

    public const int MAX_LENGTH = 50;

    public void UpdateDescription(string description)
    {
        if (!ValidateDescription(description))
            throw new DomainException($"Invalid description for payment.");

        Description = description;
        UpdatedAt = DateTime.Now;
    }

    public void UpdatePaymentDate(DateTime paymentDate)
    {
        var todayDate = DateTime.Now;
        if(todayDate < paymentDate)
            throw new DomainException($"Invalid payment date.");

        PaymentDate = paymentDate;
        UpdatedAt = todayDate;
    }

    public void UpdatePaymentType(int paymentType)
    {
        PaymentType = paymentType switch
        {
            0 => PaymentTypeEnum.Debito,
            1 => PaymentTypeEnum.Credito,
            _ => throw new DomainException("Invalid payment type.")
        };

        UpdatedAt = DateTime.Now;
    }

    public void UpdatePaymentValue(decimal paymentValue)
    {
        if(paymentValue < 0)
            throw new DomainException($"Invalid payment value, value must be greater than zero.");

        PaymentValue = paymentValue;
        UpdatedAt = DateTime.Now;
    }

    public decimal CacularSaldoConsolidado(List<decimal> saldos)
    {
        decimal total = 0;
        foreach(var saldo in saldos)
        {
            total += saldo;
        }

        return total;
    }

    private bool ValidateDescription(string description)
    {
        if (string.IsNullOrEmpty(description))
        {
            return false;
        }

        return Regex.IsMatch(description, @"[^A-Za-z0-9\ ]");
    }
}

