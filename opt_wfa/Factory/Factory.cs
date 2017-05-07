using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace opt_wfa.Factory
{
    public class Factory<T> where T:class
    {
        private Dictionary<string, Type> _foundTemlTypes =
            new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Scan all specified assemblies after food.
        /// </summary>
        public void ScanForT(params Assembly[] assemblies)
        {
            var typeT = typeof(T);
            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (!typeT.IsAssignableFrom(type) || type.IsAbstract || type.IsInterface)
                        continue;
                    _foundTemlTypes.Add(type.Name, type);
                }
            }

        }

        /// <summary>
        /// Create some food!
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public T Create(string name)
        {
            Type type;
            if (!_foundTemlTypes.TryGetValue(name, out type))
                throw new ArgumentException("Failed to find T named '" + name + "'.");

            return (T)Activator.CreateInstance(type);
        }
    }
}
