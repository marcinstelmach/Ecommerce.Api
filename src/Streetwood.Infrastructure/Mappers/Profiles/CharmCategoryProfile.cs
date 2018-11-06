using AutoMapper;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Mappers.Profiles
{
    public class CharmCategoryProfile : Profile
    {
        public CharmCategoryProfile()
            : base("CharmCategory")
        {
            CreateMap<CharmCategory, CharmCategoryDto>();
        }
    }
}
