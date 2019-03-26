using System;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class Image : Entity
    {
        public string ImageUrl { get; protected set; }

        public bool IsMain { get; protected set; }

        public virtual Product Product { get; protected set; }

        public Image(string imageUrl, bool isMain)
        {
            Id = Guid.NewGuid();
            ImageUrl = imageUrl;
            SetIsMain(isMain);
        }

        protected Image()
        {
        }

        public void SetIsMain(bool isMain)
            => IsMain = isMain;
    }
}