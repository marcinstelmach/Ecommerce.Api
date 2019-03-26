using System.Collections.Generic;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Test.Helpers
{
    public class CharmCategoryFactory
    {
        public static CharmCategory GetCharmCategory()
        {
            return new CharmCategory("Emoji", "Emoji");
        }

        public static List<CharmCategory> GetCharmCategories(int count)
        {
            var charmCategories = new List<CharmCategory>();
            for (int i = 0; i < count; i++)
            {
                charmCategories.Add(new CharmCategory($"Charm Category {i}", $"Charm Category {i}"));
            }

            return charmCategories;
        }
    }
}
