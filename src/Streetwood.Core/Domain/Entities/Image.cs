using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class Image : Entity
    {
        public string ImageUrl { get; set; }

        public bool IsMain { get; set; }

        public int ProductId { get; set; }
    }
}