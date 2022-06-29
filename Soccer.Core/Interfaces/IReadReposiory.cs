﻿using Ardalis.Specification;

namespace Soccer.Core.Interfaces
{
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}
