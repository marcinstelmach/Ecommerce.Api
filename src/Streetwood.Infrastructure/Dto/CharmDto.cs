using System;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Infrastructure.Dto
{
    public class CharmDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string NameEng { get; set; }

        public string ImagePath { get; set; }

        public decimal Price { get; set; }

        public ItemStatus Status { get; set; }
    }
}
