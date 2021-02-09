namespace Streetwood.Infrastructure.Dto
{
    using System;

    public class OrderPaymentDto
    {
        public Guid Id { get; set; }

        public PaymentDto Payment { get; set; }

        public PaymentStatusDto Status { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}