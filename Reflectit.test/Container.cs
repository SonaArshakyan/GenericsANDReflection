using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reflectit.test
{
    //Container is a map that maps from one Type to another Type
    public class Container 
    {
        Dictionary<Type, Type> _map = new Dictionary<Type, Type>();
        public ContainerBuilder For<TSource>()
        {
            return For(typeof(TSource));
        }
        public ContainerBuilder For( Type sourceType)
        {
            return new ContainerBuilder(this , sourceType);
        }
        public TSource Resolve<TSource>()
        {
            return (TSource)Resolve(typeof(TSource));

        }
        public object Resolve( Type sourceType)
        {
            if (_map.ContainsKey(sourceType))
            {
                var destinationType = _map[sourceType];
                //return Activator.CreateInstance(destinationType); // with  Default_Ctor
                return CreateInstance(destinationType);
            }
            else if(sourceType.IsGenericType && _map.ContainsKey(sourceType.GetGenericTypeDefinition()))
            {
                var destination = _map[sourceType.GetGenericTypeDefinition()];
                var closedDestionation = destination.MakeGenericType(sourceType.GetGenericArguments());
                return CreateInstance(closedDestionation);
            }
            else if (!sourceType.IsAbstract)
            {
                return CreateInstance(sourceType);
            }
            else
            {
                throw new InvalidOperationException("Could not Resolve" + sourceType.FullName);
            }
        }
        private object CreateInstance( Type destinationType)
        {
            var ctrorsInfo = destinationType.GetConstructors();
            var parametrs = destinationType.GetConstructors()
                                            .OrderByDescending(c => c.GetParameters().Count())
                                            .First()
                                            .GetParameters()
                                            .Select(p => Resolve(p.ParameterType))
                                            .ToArray();
              return Activator.CreateInstance(destinationType ,parametrs);
        }
        public class ContainerBuilder
        {
            Container _container;
            Type _sourcetype;
            public ContainerBuilder(Container container, Type sourceType)
            {
                _container = container;
                _sourcetype = sourceType;
            }

            public ContainerBuilder Use<TDestination>()
            {
                return Use(typeof(TDestination));
            }
            public ContainerBuilder Use(Type destiationType)
            {
                 _container._map.Add(_sourcetype, destiationType);
                return this;
            }
        }
    }
}
