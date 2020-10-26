using System;

namespace NewsPaper.Articles.Models.Interfaces
{
    public abstract class DomainObject
    {
       public abstract Guid Id { get; }
    }
}