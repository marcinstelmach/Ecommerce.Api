namespace Streetwood.Core.Domain.Entities
{
    public class BankTransferPayment : Payment
    {
        public int AccountNumber { get; private set; }
    }
}