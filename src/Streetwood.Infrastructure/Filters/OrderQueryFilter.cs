using System;

namespace Streetwood.Infrastructure.Filters
{
    public class OrderQueryFilter
    {
        public Guid? Id { get; set; }

        public DateTime CreationDateTime { get; set; }

        public bool IsShipped { get; set; }

        public bool IsPayed { get; set; }

        public bool IsClosed { get; set; }
    }
}
