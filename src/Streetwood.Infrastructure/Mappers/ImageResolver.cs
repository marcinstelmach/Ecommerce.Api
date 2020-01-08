using AutoMapper;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Mappers
{
    public class ImageResolver : IValueResolver<Image, ImageDto, string>
    {
        public string Resolve(Image source, ImageDto destination, string destMember, ResolutionContext context)
        {
            var startIndex = source.ImageUrl.LastIndexOf('\\') + 1;
            var indexOfLastDash = source.ImageUrl.LastIndexOf('_');
            if (startIndex < 2 || indexOfLastDash < 3)
            {
                return string.Empty;
            }

            var name = source.ImageUrl.Substring(startIndex, indexOfLastDash - startIndex);
            return name.FirstCharToUpper();
        }
    }
}
