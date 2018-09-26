using System;
using Streetwood.Core.Exceptions;

namespace Streetwood.Core.Domain.Abstract
{
    public abstract class DiscountEntity : Entity
    {
        public string Name { get; protected set; }

        public string NameEng { get; protected set; }

        public string Description { get; protected set; }

        public string DescriptionEng { get; protected set; }

        public decimal PercentValue { get; protected set; }

        public bool IsActive { get; protected set; }

        public DateTime AvaibleFrom { get; protected set; }

        public DateTime AvaibleTo { get; protected set; }

        public void SetDescription(string description)
            => Description = description;

        public void SetDescriptionEng(string description)
            => DescriptionEng = description;

        public void SetIsActive(bool isActive)
            => IsActive = isActive;

        public void SetAvaibleFrom(DateTime dateTime)
            => AvaibleFrom = dateTime;

        public DiscountEntity(string name, string nameEng, string description, string descriptionEng, decimal percentValue, bool isActive, DateTime avaibleFrom, DateTime avaibleTo)
        {
            Id = Guid.NewGuid();
            Name = name;
            NameEng = nameEng;
            SetDescription(description);
            SetDescriptionEng(descriptionEng);
            PercentValue = percentValue;
            SetIsActive(isActive);
            SetAvaibleFrom(avaibleFrom);
            SetAvaibleTo(avaibleTo);
        }

        protected DiscountEntity()
        {
        }

        public void SetAvaibleTo(DateTime dateTime)
        {
            if (dateTime < AvaibleFrom)
            {
                throw new StreetwoodException(ErrorCode.DiscountDateToIsLowerThanFrom);
            }

            AvaibleTo = dateTime;
        }

        public void SetPercentValue(decimal percentValue)
            => PercentValue = percentValue;
    }
}
