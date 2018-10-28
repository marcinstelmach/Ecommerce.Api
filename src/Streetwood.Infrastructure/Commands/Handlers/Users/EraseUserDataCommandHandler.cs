using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.Users
{
    public class EraseUserDataCommandHandler : IRequestHandler<EraseUserDataCommandModel>
    {
        private readonly IUserCommandService userCommandService;

        public EraseUserDataCommandHandler(IUserCommandService userCommandService)
        {
            this.userCommandService = userCommandService;
        }

        public async Task<Unit> Handle(EraseUserDataCommandModel request, CancellationToken cancellationToken)
        {
            await userCommandService.EraseUserDataAsync(request.Id);
            return Unit.Value;
        }
    }
}
