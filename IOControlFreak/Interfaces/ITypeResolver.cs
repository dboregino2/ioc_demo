using System;

namespace IOControlFreak.Interfaces
{
    public interface ITypeResolver
    {
        object Resolve(Type type);
    }
}