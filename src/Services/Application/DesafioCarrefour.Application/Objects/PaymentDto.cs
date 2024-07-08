﻿using DesafioCarrefour.Domain.Entities.Enums;

namespace DesafioCarrefour.Application.Objects;

public class PaymentDto
{

    public string Description { get; set; }
    public DateTime PaymentDate { get; set; }
    public int PaymentType { get; set; }
    public double PaymentValue { get; set; }
}
