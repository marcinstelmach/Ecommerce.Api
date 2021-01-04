using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Streetwood.Infrastructure.Commands.Models.Password;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.Password
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommandModel>
    {
        private readonly IUserCommandService userCommandService;
        private readonly ILogger logger;

        public UpdatePasswordCommandHandler(IUserCommandService userCommandService, 
            ILogger<UpdatePasswordCommandHandler> logger)
        {
            this.userCommandService = userCommandService;
            this.logger = logger;
        }

        public async Task<Unit> Handle(UpdatePasswordCommandModel request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Trying change password for user: '{request.Email}' with token: '{request.Token}'.");

            await userCommandService.UpdateUserPasswordAsync(request.Email, request.NewPassword, request.Token);
            logger.LogInformation($"Password successfully changed for user: '{request.Email}'.");

            return Unit.Value;
        }
    }
}
