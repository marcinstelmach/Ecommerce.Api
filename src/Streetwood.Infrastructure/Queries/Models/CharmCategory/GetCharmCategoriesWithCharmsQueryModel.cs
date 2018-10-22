using System.Collections.Generic;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.CharmCategory
{
    public class GetCharmCategoriesWithCharmsQueryModel : IRequest<IList<CharmCategoryDto>>
    {
    }
}
