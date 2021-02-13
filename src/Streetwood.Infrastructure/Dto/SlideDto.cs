namespace Streetwood.Infrastructure.Dto
{
    using System;

    public class SlideDto
    {
        public Guid Id { get; set; }

        public int OrderIndex { get; set; }

        public string Text { get; set; }

        public string TextEng { get; set; }

        public string ImageUrl { get; set; }
    }
}