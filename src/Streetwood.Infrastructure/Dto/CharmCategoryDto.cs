using System;
using System.Collections.Generic;

namespace Streetwood.Infrastructure.Dto
{
    public class CharmCategoryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string NameEng { get; set; }

        public IList<CharmDto> Charms { get; set; }
    }
}
