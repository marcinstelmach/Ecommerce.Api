namespace Streetwood.Infrastructure.Dto
{
    using System;

    public class PaymentDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string NameEng { get; set; }

        public PaymentTypeDto PaymentType { get; set; }
    }
}