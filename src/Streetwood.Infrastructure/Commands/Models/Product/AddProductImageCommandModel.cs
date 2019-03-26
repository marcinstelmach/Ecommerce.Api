using MediatR;
using Microsoft.AspNetCore.Http;
using Streetwood.Core.Exceptions;

namespace Streetwood.Infrastructure.Commands.Models.Product
{
    public class AddProductImageCommandModel : IRequest
    {
        public int ProductId { get; protected set; }

        public IFormFile File { get; protected set; }

        public bool IsMain { get; protected set; }

        public AddProductImageCommandModel(int productId, IFormFile file, bool isMain)
        {
            ProductId = productId;
            File = file;
            IsMain = isMain;
        }

        private void Validate()
        {
            if (File == null)
            {
                throw new StreetwoodException(ErrorCode.EmptyImageFile);
            }
        }
    }
}
