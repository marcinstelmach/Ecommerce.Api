using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.OrderDiscount
{
    public class UpdateOrderDiscountCommandModel : IRequest
    {
        public Guid Id { get; protected set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string NameEng { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string DescriptionEng { get; set; }

        [Required]
        [Range(0, 100)]
        public int PercentValue { get; set; }

        [Required]
        [MaxLength(30)]
        public string Code { get; set; }

        [Required]
        public DateTime AvailableFrom { get; set; }

        [Required]
        public DateTime AvailableTo { get; set; }

        public UpdateOrderDiscountCommandModel SetId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
