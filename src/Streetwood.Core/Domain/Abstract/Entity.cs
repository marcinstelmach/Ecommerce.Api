using System;

namespace Streetwood.Core.Domain.Abstract
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
    }
}
