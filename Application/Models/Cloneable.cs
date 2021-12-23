using System;

namespace Common.Application
{
    public class Cloneable<T>
    {
        public T ShallowCopy()
        {
            return (T)(MemberwiseClone());
        }
    }
}

