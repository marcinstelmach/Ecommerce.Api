using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.User;
using Streetwood.Infrastructure.Services.Abstract.Commands.User;

namespace Streetwood.Infrastructure.Commands.Handlers.User
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
            await userCommandService.AddUserAsync(request.Email, request.FirstName, request.LastName, request.Password, request.PhoneNumber);
            return Unit.Value;
        }
    }
}
