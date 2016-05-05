using System;
using System.Collections.Generic;
using System.Linq;

namespace YamlConfig
{
    /// <summary>
    /// Resolver types which contain the <see cref="YamlConfigurationAttribute"/> type
    /// </summary>
    public sealed class ConfigurationTypesResolver
    {
        /// <summary>
        /// Gets the types.
        /// </summary>
        /// <returns>
        /// List of types using the <see cref="YamlConfigurationAttribute"/>
        /// </returns>
        public static IEnumerable<ConfigurationType> GetTypes()
        {
            return from assembly in AppDomain.CurrentDomain.GetAssemblies()
                   from type in assembly.GetTypes()
                   let attribs = type.GetCustomAttributes(typeof(YamlConfigurationAttribute), false)
                   where attribs != null && attribs.Length > 0
                   select new ConfigurationType() { Type = type, Attribute = attribs.First() as YamlConfigurationAttribute };
        }
    }
}
