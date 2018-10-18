using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Streetwood.Infrastructure.Commands.Models
{
    public class AddProductImageCommandModel : IRequest
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public IFormFile File { get; set; }

        [Required]
        public bool IsMain { get; set; }

        public AddProductImageCommandModel()
        {
        }

        public AddProductImageCommandModel(int productId, IFormFile file, bool isMain)
        {
            ProductId = productId;
            File = file;
            IsMain = isMain;
        }
    }
}
