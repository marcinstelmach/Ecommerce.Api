using MediatR;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Dto.Products;

namespace Streetwood.Infrastructure.Queries.Models.Product
{
    public class GetProductByIdQueryModel : IRequest<ProductDto>
    {
        public int Id { get; set; }

        public GetProductByIdQueryModel(int id)
        {
            Id = id;
        }
    }
}
