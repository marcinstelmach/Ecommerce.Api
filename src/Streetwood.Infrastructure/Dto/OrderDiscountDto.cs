using System;

namespace Streetwood.Infrastructure.Dto
{
    public class OrderDiscountDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string NameEng { get; set; }

        public string Description { get; set; }

        public string DescriptionEng { get; set; }

        public int PercentValue { get; set; }

        public bool IsActive { get; set; }

        public string Code { get; set; }

        public DateTime AvailableFrom { get; set; }

        public DateTime AvailableTo { get; set; }
    }
}
