﻿using Thoughts.Interfaces.Base.Entities;

namespace Thoughts.Interfaces;

public interface ITag<TKye> : INamedEntity<TKye>
{
    public ICollection<IPost<TKye>> Posts { get; set; }
}
