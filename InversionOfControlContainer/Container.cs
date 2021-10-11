using System;
using System.Collections.Generic;
using System.Linq;

namespace InversionOfControlContainer
{
    public class Container : IContainer
    {
        private readonly Dictionary<Type, Type> _types;

        public Container()
        {
            _types = new Dictionary<Type, Type>();
        }
        
        public void RegisterService<TInterface, TImplementation>() where TImplementation : TInterface
        {
            _types[typeof(TInterface)] = typeof(TImplementation);
        }

        public void RegisterService<TImplementation>() where TImplementation : class
        {
            RegisterService<TImplementation, TImplementation>();
        }

        public bool IsServiceRegistered(Type type)
        {
            return _types.ContainsKey(type);
        }

        public TInterface ResolveService<TInterface>()
        {
            if (!IsServiceRegistered(typeof(TInterface)))
            {
                throw new ArgumentException();
            }
            
            return (TInterface) ResolveService(typeof(TInterface));
        }

        private object ResolveService(Type type)
        {
            var concreteType = _types[type];

            var defaultConstructor = concreteType.GetConstructors()[0];

            var constructorParamsInfo = defaultConstructor.GetParameters();

            var parameters = constructorParamsInfo
                .Select(p => ResolveService(p.ParameterType))
                .ToArray();

            return defaultConstructor.Invoke(parameters);
        }
    }
}