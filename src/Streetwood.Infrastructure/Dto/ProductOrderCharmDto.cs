namespace Streetwood.Infrastructure.Dto
{
    public class ProductOrderCharmDto
    {
        public decimal CurrentPrice { get; set; }

        public int Sequence { get; set; }

        public virtual CharmDto Charm { get; set; }
    }
}
