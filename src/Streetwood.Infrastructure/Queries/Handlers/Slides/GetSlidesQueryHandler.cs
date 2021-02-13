namespace Streetwood.Infrastructure.Queries.Handlers.Slides
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using MediatR;
    using Streetwood.Core.Domain.Abstract.Repositories;
    using Streetwood.Core.Domain.Entities;
    using Streetwood.Infrastructure.Dto;
    using Streetwood.Infrastructure.Queries.Models.Slides;

    public class GetSlidesQueryHandler : IRequestHandler<GetSlidesQueryModel, IEnumerable<SlideDto>>
    {
        private readonly ISlidesRepository slidesRepository;
        private readonly IMapper mapper;

        public GetSlidesQueryHandler(ISlidesRepository slidesRepository, IMapper mapper)
        {
            this.slidesRepository = slidesRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SlideDto>> Handle(GetSlidesQueryModel request, CancellationToken cancellationToken)
        {
            var slides = await slidesRepository.GetSlidesAsync();
            return mapper.Map<IEnumerable<Slide>, IEnumerable<SlideDto>>(slides);
        }
    }
}