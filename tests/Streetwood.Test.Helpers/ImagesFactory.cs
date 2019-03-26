using System.Collections.Generic;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Test.Helpers
{
    public class ImagesFactory
    {
        public static Image GetImage()
            => new Image("", true);

        public static List<Image> GetImages(int count)
        {
            var images = new List<Image>();
            for (int i = 0; i < count; i++)
            {
                images.Add(new Image("", false));
            }

            images[0].SetIsMain(true);
            return images;
        }
    }
}
