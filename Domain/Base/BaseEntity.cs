﻿namespace Domain.Base
{
    public abstract class BaseEntity
    {
        
    }

    public abstract class Entity<T> : BaseEntity
    {
        public virtual T Id { get; set; }
    }
}