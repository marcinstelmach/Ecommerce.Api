using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.Product
{
    public class DeleteProductCommandModel : IRequest
    {
        public int Id { get; protected set; }

        public DeleteProductCommandModel(int id)
        {
            Id = id;
        }
    }
}
