namespace Streetwood.Infrastructure.Dto
{
    using System;
    using Streetwood.Core.Domain.Enums;

    public class PaymentDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string NameEng { get; set; }

        public PaymentType PaymentType { get; set; }
    }
}