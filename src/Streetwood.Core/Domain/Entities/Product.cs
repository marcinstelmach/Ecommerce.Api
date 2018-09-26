using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Core.Domain.Entities
{
    public class Product : Entity
    {
        private List<Image> images = new List<Image>();
        private List<ProductOrder> productOrders = new List<ProductOrder>();

        public new int Id { get; protected set; }

        public string Name { get; protected set; }

        public string NameEng { get; protected set; }

        public decimal Price { get; protected set; }

        public ProductStatus Status { get; protected set; }

        public string Description { get; protected set; }

        public string DescriptionEng { get; protected set; }

        public bool AcceptCharms { get; protected set; }

        public string Sizes { get; protected set; }

        public virtual ProductCategory ProductCategory { get; protected set; }

        public virtual IReadOnlyCollection<Image> Images => images;

        public virtual IReadOnlyCollection<ProductOrder> ProductOrders => productOrders;

        public Product(string name, decimal price, string description, bool acceptCharms, string sizes)
        {
            SetName(name);
            SetPrice(price);
            SetDescription(description);
            AcceptCharms = acceptCharms;
            SetSizes(sizes);
            Status = ProductStatus.Avaible;
        }

        protected Product()
        {
        }

        public void SetName(string name)
            => Name = name;

        public void SetNameEng(string name)
            => NameEng = name;

        public void SetPrice(decimal price)
            => Price = price;

        public void SetDescription(string description)
            => Description = description;

        public void SetDescriptionEng(string description)
            => DescriptionEng = description;

        public void SetSizes(string sizes)
            => Sizes = sizes;

        public void AddImage(Image image)
            => images.Add(image);
    }
}