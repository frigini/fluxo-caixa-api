using System.Text.RegularExpressions;
using DesafioCarrefour.Core.DomainObjects;

namespace DesafioCarrefour.Domain.Entities;

public partial class Payment : Entity
{
    protected Payment() { }

    public Payment(
        string description, 
        DateTime paymentDate, 
        string paymentType, 
        double paymentValue)
    {
        UpdateDescription(description);
        UpdatePaymentDate(paymentDate);
        UpdatePaymentType(paymentType);
        UpdatePaymentValue(paymentValue);
    }

    public string Description { get; private set; }
    public DateTime PaymentDate { get; private set; }
    public string PaymentType { get; private set; } //possível enum
    public double PaymentValue { get; private set; }

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
        UpdatedAt = DateTime.Now;
    }

    public void UpdatePaymentType(string paymentType)
    {
        if(string.IsNullOrEmpty(paymentType))
            throw new DomainException($"Invalid type {paymentType} to a payment.");

        PaymentType = paymentType;
        UpdatedAt = DateTime.Now;
    }

    public void UpdatePaymentValue(double paymentValue)
    {
        if(paymentValue < 0)
            throw new DomainException($"Invalid payment value, value must be greater than zero.");

        PaymentValue = paymentValue;
        UpdatedAt = DateTime.Now;
    }

    private bool ValidateDescription(string description)
    {
        if (string.IsNullOrEmpty(description))
        {
            return false;
        }

        return SpecialCharactersStringRegex().IsMatch(description);
    }

    [GeneratedRegex("^(?=.*[A-ZÀ-ÿ~])(?=.*[a-zà-ÿ~])[A-Za-zÀ-ÿ~]+$")]
    private static partial Regex SpecialCharactersStringRegex();
}

