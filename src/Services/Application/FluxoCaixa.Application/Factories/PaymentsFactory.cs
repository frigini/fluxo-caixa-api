using System.Collections.Generic;
using FluxoCaixa.Application.Objects.Requests;
using FluxoCaixa.Application.Objects.Responses;
using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Application.Factories
{
    public static class PaymentsFactory
    {
        public static Payment ToDomain(this PaymentRequest payment)
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

        public static IEnumerable<PaymentResponse> ToResponse(this IEnumerable<Payment> payments) => payments.Select(p => p.ToResponse()).ToList();
    }
}
