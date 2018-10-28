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

        public int PercentValue { get; protected set; }

        public bool IsActive { get; protected set; }

        public DateTime AvailableFrom { get; protected set; }

        public DateTime AvailableTo { get; protected set; }

        public void SetDescription(string description)
            => Description = description;

        public void SetDescriptionEng(string description)
            => DescriptionEng = description;

        public void SetIsActive(bool isActive)
            => IsActive = isActive;

        public void SetAvaibleFrom(DateTime dateTime)
            => AvailableFrom = dateTime;

        public DiscountEntity(string name, string nameEng, string description, string descriptionEng, int percentValue, bool isActive, DateTime avaibleFrom, DateTime avaibleTo)
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
            if (dateTime < AvailableFrom)
            {
                throw new StreetwoodException(ErrorCode.DiscountDateToIsLowerThanFrom);
            }

            AvailableTo = dateTime;
        }

        public void SetPercentValue(int percentValue)
            => PercentValue = percentValue;
    }
}
