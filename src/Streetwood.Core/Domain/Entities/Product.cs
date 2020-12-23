using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Core.Domain.Entities
{

    public class Product : Entity
    {
        private readonly List<Image> images = new List<Image>();
        private readonly List<ProductOrder> productOrders = new List<ProductOrder>();
        private readonly List<ProductColor> productColors = new List<ProductColor>();

        public new int Id { get; set; }

        public string Name { get; protected set; }

        public string NameEng { get; protected set; }

        public string Description { get; protected set; }

        public string DescriptionEng { get; protected set; }

        public decimal Price { get; protected set; }

        public bool AcceptCharms { get; protected set; }

        public int MaxCharmsCount { get; protected set; }

        public bool AcceptGraver { get; protected set; }

        public string Sizes { get; protected set; }

        public string ImagesPath { get; protected set; }

        public ItemStatus Status { get; protected set; }

        public Guid ProductCategoryId { get; protected set; }

        public virtual ProductCategory ProductCategory { get; protected set; }

        public virtual IReadOnlyCollection<Image> Images => images;

        public virtual IReadOnlyCollection<ProductOrder> ProductOrders => productOrders;

        public virtual IReadOnlyCollection<ProductColor> ProductColors => productColors;

        public Product(string name, string nameEng, decimal price, string description, string descriptionEng,
            bool acceptCharms, bool acceptGraver, int maxCharmsCount, string sizes, string imagesPath)
        {
            SetName(name);
            SetNameEng(nameEng);
            SetPrice(price);
            SetDescription(description);
            SetDescriptionEng(descriptionEng);
            AcceptCharms = acceptCharms;
            AcceptGraver = acceptGraver;
            SetSizes(sizes);
            SetStatus(ItemStatus.Available);
            ImagesPath = imagesPath;
            MaxCharmsCount = maxCharmsCount;
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

        public void SetStatus(ItemStatus status)
            => Status = status;

        public void SetAcceptCharms(bool acceptCharms)
            => AcceptCharms = acceptCharms;

        public void SetAcceptGraver(bool acceptGraver)
            => AcceptGraver = acceptGraver;

        public void AddImage(Image image)
            => images.Add(image);

        public void AddProductColors(IEnumerable<ProductColor> productColors)
        {
            this.productColors.Clear();
            this.productColors.AddRange(productColors);
        }

        internal void SetProductCategory(ProductCategory productCategory)
            => ProductCategory = productCategory;
    }
}