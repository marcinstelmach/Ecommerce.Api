using System;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.CharmCategory
{
    public class GetCharmCategoryWithCharmsQueryModel : IRequest<CharmCategoryDto>
    {
        public Guid Id { get; protected set; }

        public GetCharmCategoryWithCharmsQueryModel(Guid id)
        {
            Id = id;
        }
    }
}
