using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers
{
    public class AddCharmImageCommandHandler : IRequestHandler<AddCharmImageCommandModel, Unit>
    {
        private readonly ICharmCommandService charmCommandService;

        public AddCharmImageCommandHandler(ICharmCommandService charmCommandService)
        {
            this.charmCommandService = charmCommandService;
        }

        public async Task<Unit> Handle(AddCharmImageCommandModel request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
