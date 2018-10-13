using System;
using System.Collections.Generic;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.Charm
{
    public class GetCharmsByCategoryIdQueryModel : IRequest<IList<CharmDto>>
    {
        public Guid Id { get; }

        public GetCharmsByCategoryIdQueryModel(Guid id)
        {
            Id = id;
        }
    }
}
