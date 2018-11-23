using System;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.Charm
{
    public class AddCharmCommandModel : IRequest<Guid>
    {
        public string Name { get; set; }

        public string NameEng { get; set; }

        public decimal Price { get; set; }

        public Guid CharmCategoryId { get; set; }
    }
}
