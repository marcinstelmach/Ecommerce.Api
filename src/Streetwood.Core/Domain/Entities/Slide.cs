namespace Streetwood.Core.Domain.Entities
{
    using System;
    using Streetwood.Core.Domain.Abstract;

    public class Slide : Entity
    {
        public Slide(int orderIndex, string text, string textEng)
        {
            Id = Guid.NewGuid();
            OrderIndex = orderIndex;
            Text = text;
            TextEng = textEng;
        }

        protected Slide()
        {
        }

        public int OrderIndex { get; protected set; }

        public string Text { get; protected set; }

        public string TextEng { get; protected set; }

        public string ImageUrl { get; protected set; }

        public void SetImageUrl(string imageUrl) => ImageUrl = imageUrl;
    }
}