using System.Collections.Generic;
using DesafioCarrefour.Application.Objects;
using DesafioCarrefour.Domain.Entities;

namespace DesafioCarrefour.Application.Factories
{
    public static class PaymentsFactory
    {
        public static Payment ToDomain(this PaymentDto payment)
        {
            return new Payment
            (
                payment.Description,
                payment.PaymentDate,
                payment.PaymentType,
                payment.PaymentValue
            );
        }

        public static PaymentResponse ToResponse(this Payment payment) => new PaymentResponse
        (
            payment.Description,
            payment.PaymentType.ToString(),
            payment.PaymentValue,
            payment.PaymentDate
        );

        public static List<PaymentResponse> ToResponse(this List<Payment> payments) => payments.Select(p => p.ToResponse()).ToList();
    }
}
