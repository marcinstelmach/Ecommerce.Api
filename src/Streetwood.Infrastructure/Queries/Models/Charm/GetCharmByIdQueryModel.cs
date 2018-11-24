using System;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.Charm
{
    public class GetCharmByIdQueryModel : IRequest<CharmDto>
    {
        public Guid Id { get; }

        public GetCharmByIdQueryModel(Guid id)
        {
            Id = id;
        }
    }
}
