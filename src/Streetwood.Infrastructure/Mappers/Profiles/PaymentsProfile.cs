namespace Streetwood.Infrastructure.Mappers.Profiles
{
    using AutoMapper;
    using Streetwood.Core.Domain.Entities;
    using Streetwood.Infrastructure.Dto;

    public class PaymentsProfile : Profile
    {
        public PaymentsProfile()
            : base("Payments")
        {
            CreateMap<Payment, PaymentDto>();

            CreateMap<BankTransferPayment, BankTransferPaymentDto>()
                .IncludeBase<Payment, PaymentDto>();
        }
    }
}