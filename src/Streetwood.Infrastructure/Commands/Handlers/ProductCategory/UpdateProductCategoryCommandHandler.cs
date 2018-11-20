using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.ProductCategory;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.ProductCategory
{
    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommandModel, Unit>
    {
        private readonly IProductCategoryCommandService service;

        public UpdateProductCategoryCommandHandler(IProductCategoryCommandService service)
        {
            this.service = service;
        }

        public async Task<Unit> Handle(UpdateProductCategoryCommandModel request, CancellationToken cancellationToken)
        {
            await service.UpdateAsync(request.Id, request.Name, request.NameEng);
            return Unit.Value;
        }
    }
}
