using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDNet10.Domain.Common
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
    }
}
