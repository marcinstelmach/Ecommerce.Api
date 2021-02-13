namespace Streetwood.Infrastructure.Queries.Handlers.Slides
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using MediatR;
    using Streetwood.Core.Constants;
    using Streetwood.Core.Domain.Abstract.Repositories;
    using Streetwood.Core.Domain.Entities;
    using Streetwood.Infrastructure.Dto;
    using Streetwood.Infrastructure.Managers.Abstract;
    using Streetwood.Infrastructure.Queries.Models.Slides;

    public class GetSlidesQueryHandler : IRequestHandler<GetSlidesQueryModel, IEnumerable<SlideDto>>
    {
        private readonly ISlidesRepository slidesRepository;
        private readonly IMapper mapper;
        private readonly ICache cache;

        public GetSlidesQueryHandler(ISlidesRepository slidesRepository, IMapper mapper, ICache cache)
        {
            this.slidesRepository = slidesRepository;
            this.mapper = mapper;
            this.cache = cache;
        }

        public async Task<IEnumerable<SlideDto>> Handle(GetSlidesQueryModel request, CancellationToken cancellationToken)
        {
            var slides = await cache.GetOrCreateAsync(CacheKey.Slides, x => slidesRepository.GetSlidesAsync(), request.UserType);
            return mapper.Map<IEnumerable<Slide>, IEnumerable<SlideDto>>(slides);
        }
    }
}