using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Models
{
    public class CharmCategory : Entity
    {
        public string Name { get; set; }
        public ICollection<Charm> Charms { get; set; }
    }
}