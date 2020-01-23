using System;

namespace Streetwood.Infrastructure.Dto
{
    public class ImageDto
    {
        public Guid Id { get; set; }

        public string ImageUrl { get; set; }

        public bool IsMain { get; set; }

        public string Name { get; set; }
    }
}
