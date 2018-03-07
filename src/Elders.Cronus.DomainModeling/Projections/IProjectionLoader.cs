﻿using System;

namespace Elders.Cronus.DomainModeling.Projections
{
    public interface IProjectionLoader
    {
        IProjectionGetResult<T> Get<T>(IBlobId projectionId) where T : IProjectionDefinition;
        IProjectionGetResult<IProjectionDefinition> Get(IBlobId projectionId, Type projectionType);
    }
}
