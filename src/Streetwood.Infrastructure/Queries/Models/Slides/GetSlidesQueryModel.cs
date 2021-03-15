namespace Streetwood.Infrastructure.Queries.Models.Slides
{
    using System.Collections.Generic;
    using MediatR;
    using Streetwood.Core.Domain.Enums;
    using Streetwood.Infrastructure.Dto;

    public class GetSlidesQueryModel : IRequest<IEnumerable<SlideDto>>
    {
        public GetSlidesQueryModel(UserType userType)
        {
            UserType = userType;
        }

        public UserType UserType { get; set; }
    }
}