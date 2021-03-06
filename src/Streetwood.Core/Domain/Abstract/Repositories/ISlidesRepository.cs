﻿namespace Streetwood.Core.Domain.Abstract.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Streetwood.Core.Domain.Entities;

    public interface ISlidesRepository : IRepository<Slide>
    {
        Task<IEnumerable<Slide>> GetSlidesAsync();

        Task<int> GetLastOrderIndexAsync();

        void Add(Slide slide);
    }
}