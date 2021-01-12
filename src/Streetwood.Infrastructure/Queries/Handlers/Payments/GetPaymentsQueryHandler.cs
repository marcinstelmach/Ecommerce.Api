namespace Streetwood.Infrastructure.Queries.Handlers.Payments
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using MediatR;
    using Streetwood.Core.Domain.Abstract.Repositories;
    using Streetwood.Infrastructure.Dto;
    using Streetwood.Infrastructure.Queries.Models.Payments;

    public class GetPaymentsQueryHandler : IRequestHandler<GetPaymentsQueryModel, IEnumerable<PaymentDto>>
    {
        private readonly IPaymentsRepository paymentsRepository;
        private readonly IMapper mapper;

        public GetPaymentsQueryHandler(IPaymentsRepository paymentsRepository, IMapper mapper)
        {
            this.paymentsRepository = paymentsRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PaymentDto>> Handle(GetPaymentsQueryModel request, CancellationToken cancellationToken)
        {
            var payments = await paymentsRepository.GetPaymentsAsync();
            return mapper.Map<IEnumerable<PaymentDto>>(payments);
        }
    }
}