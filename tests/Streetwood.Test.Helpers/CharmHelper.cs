using System.Collections.Generic;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Test.Helpers
{
    public class CharmHelper
    {
        public static IList<Charm> CreateCharms(int count)
        {
            var charms = new List<Charm>();
            for (var i = 0; i < count; i++)
            {
                charms.Add(new Charm($"Charm{i}", $"Charm{i}", "somePath", 5));
            }

            return charms;
        }
    }
}
