namespace Streetwood.Infrastructure.Queries.Models.Slides
{
    using System.Collections.Generic;
    using MediatR;
    using Streetwood.Infrastructure.Dto;

    public class GetSlidesQueryModel : IRequest<IEnumerable<SlideDto>>
    {
    }
}