using System;
using System.Linq;

namespace Calculator.Domain
{
    public static class Factory
    {
        public static T Get<T>(string name) where T : class
        {
            return typeof(T)
                .Assembly
                .GetTypes()
                .Where(type => type.GetInterfaces().Contains(typeof(T)))
                .Where(type => type.Name.Equals(name))
                .Select(type => Activator.CreateInstance(type) as T)
                .SingleOrDefault();
        }
    }
}
