using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NLog;
using Streetwood.Infrastructure.Commands.Models.Password;
using Streetwood.Infrastructure.Services.Abstract;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Commands.Handlers.Password
{
    public class SendPasswordResetEmailCommandHandler : IRequestHandler<SendPasswordResetEmailCommandModel>
    {
        private readonly IEmailService emailService;
        private readonly IUserQueryService userQueryService;
        private readonly ILogger logger;

        public SendPasswordResetEmailCommandHandler(IEmailService emailService, IUserQueryService userQueryService, ILogger logger)
        {
            this.emailService = emailService;
            this.userQueryService = userQueryService;
            this.logger = logger;
        }

        public async Task<Unit> Handle(SendPasswordResetEmailCommandModel request, CancellationToken cancellationToken)
        {
            logger.Info($"Triggered password reset for email: {request.Email}");
            var user = await userQueryService.CreateChangePasswordTokenAsync(request.Email);

            await emailService.SendForgottenPasswordEmailAsync(user);
            logger.Info($"Successfully send password");
            return Unit.Value;
        }
    }
}
