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

        public static IEnumerable<CharmCategory> GetCharmCategories(int count)
        {
            var charmCategories = new List<CharmCategory>();
            for (int i = 0; i < count; i++)
            {
                charmCategories.Add(new CharmCategory($"Charm Category {i}", $"Charm Category {i}"));
            }

            return charmCategories;
        }

        public static IEnumerable<CharmCategory> GetCharmCategoriesWithCharms(int categories, int charmsInCategory)
        {
            var charmCategories = new List<CharmCategory>();
            for (var i = 0; i < categories; i++)
            {
                var charmCategory = new CharmCategory($"Charm Category {i}", $"Charm Category {i}");
                charmCategory.AddCharms(CharmFactory.GetCharms(charmsInCategory));
                charmCategories.Add(charmCategory);
            }

            return charmCategories;
        }
    }
}
