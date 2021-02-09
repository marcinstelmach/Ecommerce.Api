namespace Streetwood.Core.Domain.Entities
{
    using Streetwood.Core.Domain.Abstract;
    using Streetwood.Core.Domain.Enums;

    public abstract class Payment : Entity
    {
        public PaymentType PaymentType { get; protected set; }

        public string Name { get; protected set; }

        public string NameEng { get; protected set; }
    }
}