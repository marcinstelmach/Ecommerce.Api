namespace Streetwood.Core.Domain.Entities
{
    public class BankTransferPayment : Payment
    {
        public long AccountNumber { get; private set; }
    }
}