namespace Streetwood.Core.Domain.Entities
{
    using Streetwood.Core.Domain.Abstract;

    public class Slide : Entity
    {
        public int OrderIndex { get; set; }

        public string Text { get; set; }

        public string TextEng { get; set; }

        public string ImageUrl { get; set; }
    }
}