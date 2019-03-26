using System.Collections.Generic;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Test.Helpers
{
    public class CharmFactory
    {
        public static Charm GetCharm()
        {
            return new Charm("Crying emoji", "CryingEmoji", "", 5);
        }

        public static List<Charm> GetCharms(int count)
        {
            var charms = new List<Charm>();
            for (int i = 0; i < count; i++)
            {
                charms.Add(new Charm($"Charm{i}", $"Charm{i}", "", 5));
            }

            return charms;
        }
    }
}
