using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyFinancial.Common.IOC
{
    public static class ObjectResolver
    {
        private static IUnityContainer _container;
        public static void SetContainer(IUnityContainer container)
        {
            if(container == null)
                throw new ArgumentException("container is null");

            _container = container;
        }

        public static T Resolver<T>()
        {
            if (_container.IsRegistered<T>())
                return _container.Resolve<T>();

            return default(T);
        }

        public static object Resolver(Type type)
        {
            return _container.Resolve(type);
        }




    }
}
