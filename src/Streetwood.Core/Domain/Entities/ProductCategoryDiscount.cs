using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Exceptions;

namespace Streetwood.Core.Domain.Entities
{
    public class ProductCategoryDiscount : Entity
    {
        private List<ProductCategory> productCategories = new List<ProductCategory>();

        public string Name { get; protected set; }

        public string NameEng { get; protected set; }

        public string Description { get; protected set; }

        public string DescriptionEng { get; protected set; }

        public decimal PercentValue { get; protected set; }

        public bool IsActive { get; protected set; }

        public DateTime AvaibleFrom { get; protected set; }

        public DateTime AvaibleTo { get; protected set; }

        public virtual IReadOnlyCollection<ProductCategory> ProductCategories { get; set; }


        // constructors

        public void SetDescription(string description)
            => Description = description;

        public void SetDescriptionEng(string description)
            => DescriptionEng = description;

        public void SetIsActive(bool isActive)
            => IsActive = isActive;

        public void SetAvaibleFrom(DateTime dateTime)
            => AvaibleFrom = dateTime;

        public void SetAvaibleTo(DateTime dateTime)
        {
            if (dateTime < AvaibleFrom)
            {
                throw new StreetwoodException(ErrorCode.DiscountDateToIsLowerThanFrom);
            }

            AvaibleTo = dateTime;
        }
    }
}