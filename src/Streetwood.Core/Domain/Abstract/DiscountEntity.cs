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

        public bool IsActive => AvailableTo >= DateTime.Now;

        public DateTime AvailableFrom { get; protected set; }

        public DateTime AvailableTo { get; protected set; }

        public void SetDescription(string description)
            => Description = description;

        public void SetDescriptionEng(string description)
            => DescriptionEng = description;

        public void SetAvailableFrom(DateTime dateTime)
            => AvailableFrom = dateTime;

        protected DiscountEntity(string name, string nameEng, string description, string descriptionEng, int percentValue, DateTime availableFrom, DateTime availableTo)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetNameEng(nameEng);
            SetDescription(description);
            SetDescriptionEng(descriptionEng);
            PercentValue = percentValue;
            SetAvailableFrom(availableFrom);
            SetAvailableTo(availableTo);
        }

        protected DiscountEntity()
        {
        }

        public void SetAvailableTo(DateTime dateTime)
        {
            if (dateTime < AvailableFrom)
            {
                throw new StreetwoodException(ErrorCode.DiscountDateToIsLowerThanFrom);
            }

            AvailableTo = dateTime;
        }

        public void SetPercentValue(int percentValue)
            => PercentValue = percentValue;

        public void SetName(string name)
            => Name = name;

        public void SetNameEng(string name)
            => NameEng = name;
    }
}
