using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.CharmCategory;

namespace Streetwood.Infrastructure.Commands.Handlers
{
    public class AddCharmCategoryCommandHandler : IRequestHandler<AddCharmCategoryCommandModel, Unit>
    {
        public async Task<Unit> Handle(AddCharmCategoryCommandModel request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
