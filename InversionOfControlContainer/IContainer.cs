using System;

namespace InversionOfControlContainer
{
    public interface IContainer
    {
        void RegisterService<TInterface, TImplementation>() where TImplementation : TInterface;
        void RegisterService<TImplementation>() where TImplementation : class;
        bool IsServiceRegistered(Type type);
        TInterface ResolveService<TInterface>();
    }
}