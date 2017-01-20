using System.Collections.Generic;

namespace Hierarchy
{
    public interface IHaveChildren<T>
    {
        IEnumerable<IHaveChildren<T>> Children { get;}
    }
}