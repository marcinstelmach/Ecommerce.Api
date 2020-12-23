namespace Streetwood.Core.Domain.Entities
{
    public class ProductColor
    {
        public ProductColor(string name, string hexValue)
        {
            Name = name;
            HexValue = hexValue;
        }

        protected ProductColor()
        {
        }

        public int ProductId { get; protected set; }

        public string Name { get; protected set; }

        public string HexValue { get; protected set; }

        public virtual Product Product { get; protected set; }
    }
}