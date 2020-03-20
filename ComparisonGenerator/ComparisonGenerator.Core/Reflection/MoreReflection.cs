using System;
using System.Collections.Generic;
using System.Text;

namespace ComparisonGenerator.Core.Reflection
{
    public static class MoreReflection
    {
        public static bool ImplementsOpenGenericInterface(this Type thisType, Type ogiType)
        {
            if (thisType is null) throw new ArgumentNullException(nameof(thisType));

            ValidateThatTypeIsOpenGenericInterfaceType(ogiType);

            foreach (Type interfaceType in thisType.GetInterfaces())
            {
                if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == ogiType)
                    return true;
            }

            return false;
        }

        public static Type GetTypeImplementingOpenGenericInterface(this Type thisType, Type ogiType)
        {
            if (!thisType.ImplementsOpenGenericInterface(ogiType))
                throw new ArgumentException($"{thisType.Name} does not implement the open generic type {ogiType.Name}");

            foreach (Type interfaceType in thisType.GetInterfaces())
            {
                if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == ogiType)
                    return interfaceType.GetGenericArguments()[0];
            }

            return default;
        }

        private static void ValidateThatTypeIsOpenGenericInterfaceType(Type ogiType)
        {
            if (ogiType is null) throw new ArgumentNullException(nameof(ogiType));
            if (!ogiType.IsInterface || !ogiType.IsGenericType)
                throw new ArgumentException($"The provided type must be an open generic interface type");
        }
    }
}