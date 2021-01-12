namespace Streetwood.Core.Domain.Entities
{
    using Streetwood.Core.Domain.Abstract;
    using Streetwood.Core.Domain.Enums;

    public class Payment : Entity
    {
        public string Name { get; protected set; }

        public string NameEng { get; protected set; }

        public PaymentType PaymentType { get; protected set; }
    }
}