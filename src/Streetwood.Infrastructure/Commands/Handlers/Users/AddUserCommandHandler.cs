using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.User;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.Users
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommandModel, Unit>
    {
        private readonly IUserCommandService userCommandService;

        public AddUserCommandHandler(IUserCommandService userCommandService)
        {
            this.userCommandService = userCommandService;
        }

        public async Task<Unit> Handle(AddUserCommandModel request, CancellationToken cancellationToken)
        {
            await userCommandService.AddUserAsync(request.Email, request.FirstName, request.LastName, request.Password);
            return Unit.Value;
        }
    }
}
