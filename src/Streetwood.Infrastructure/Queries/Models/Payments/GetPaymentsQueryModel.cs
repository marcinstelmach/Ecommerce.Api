namespace Streetwood.Infrastructure.Queries.Models.Payments
{
    using System.Collections.Generic;
    using MediatR;
    using Streetwood.Infrastructure.Dto;

    public class GetPaymentsQueryModel : IRequest<IEnumerable<PaymentDto>>
    {
    }
}