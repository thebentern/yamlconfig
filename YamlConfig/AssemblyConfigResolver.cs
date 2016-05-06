using System;
using System.Collections.Generic;
using System.Linq;

namespace YamlConfig
{
    /// <summary>
    /// Resolver types which contain the <see cref="YamlConfigAttribute"/> type
    /// </summary>
    public sealed class AssemblyConfigResolver
    {
        /// <summary>
        /// Gets the types.
        /// </summary>
        /// <returns>
        /// List of types using the <see cref="YamlConfigAttribute"/>
        /// </returns>
        public static IEnumerable<ConfigType> GetTypes()
        {
            return from assembly in AppDomain.CurrentDomain.GetAssemblies()
                   from type in assembly.GetTypes()
                   let attribs = type.GetCustomAttributes(typeof(YamlConfigAttribute), false)
                   where attribs != null && attribs.Length > 0
                   select new ConfigType() { Type = type, Attribute = attribs.First() as YamlConfigAttribute };
        }
    }
}
