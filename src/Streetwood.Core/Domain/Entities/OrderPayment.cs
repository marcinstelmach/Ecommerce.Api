namespace Streetwood.Core.Domain.Entities
{
    using System;
    using Streetwood.Core.Domain.Abstract;
    using Streetwood.Core.Domain.Enums;
    using Streetwood.Core.Exceptions;

    public class OrderPayment : Entity
    {
        public OrderPayment(Payment payment)
        {
            Id = Guid.NewGuid();
            SetPayment(payment);
            Status = PaymentStatus.Pending;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        protected OrderPayment()
        {
        }

        public virtual Payment Payment { get; protected set; }

        public PaymentStatus Status { get; protected set; }

        public DateTimeOffset UpdatedAt { get; protected set; }

        public void Complete()
        {
            if (Status != PaymentStatus.Pending)
            {
                throw new StreetwoodException(ErrorCode.CannotCompleteNotPendingPayment);
            }

            Status = PaymentStatus.Completed;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        private void SetPayment(Payment payment)
            => Payment = payment;
    }
}