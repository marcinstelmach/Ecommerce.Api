using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Core.Domain.Entities
{
    public class Charm : Entity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
        public CharmStatus Type { get; set; }
        public int CharmCategoryId { get; set; }
        public CharmCategory CharmCategory { get; set; }
    }
}