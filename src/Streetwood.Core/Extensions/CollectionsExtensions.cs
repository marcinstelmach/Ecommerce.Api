using System;
using System.Collections.Generic;
using System.Linq;
using Streetwood.Core.Exceptions;

namespace Streetwood.Core.Extensions
{
    public static class CollectionsExtensions
    {
        public static T EnsureSingleExists<T>(this IEnumerable<T> collection, Func<T, bool> condition)
        {
            var record = collection.SingleOrDefault(condition);
            if (record == null)
            {
                throw new StreetwoodException(ErrorCode.GenericNotExist(typeof(T)));
            }

            return record;
        }
    }
}
