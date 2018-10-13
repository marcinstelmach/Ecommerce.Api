using System;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models
{
    public class AddCharmCommandModel : IRequest
    {
        public string Name { get; set; }

        public string NameEng { get; set; }

        public decimal Price { get; set; }

        public Guid CharmCategoryId { get; private set; }

        public AddCharmCommandModel AddCategoryId(Guid guid)
        {
            CharmCategoryId = guid;
            return this;
        }

    }
}
