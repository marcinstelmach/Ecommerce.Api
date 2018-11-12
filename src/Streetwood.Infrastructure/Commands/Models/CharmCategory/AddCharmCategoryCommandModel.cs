using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.CharmCategory
{
    public class AddCharmCategoryCommandModel : IRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string NameEng { get; set; }
    }
}
