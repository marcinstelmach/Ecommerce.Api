using System;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.Product
{
    public class DeleteProductCommandModel : IRequest
    {
        public int Id { get; protected set; }

        public Guid CategoryId { get; protected set; }

        public DeleteProductCommandModel(int id, Guid categoryId)
        {
            Id = id;
            CategoryId = categoryId;
        }
    }
}
