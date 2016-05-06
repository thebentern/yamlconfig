using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace YamlConfig
{
    /// <summary>
    /// Bootstrapper for loading the configuration
    /// </summary>
    public class ConfigProvider<T> : IConfigProvider<T>
    {
        private static readonly IEnumerable<ConfigType> ConfigTypes;

        /// <summary>
        /// Initializes the <see cref="ConfigProvider{T}"/> class.
        /// </summary>
        static ConfigProvider()
        {
            ConfigTypes = AssemblyConfigResolver.GetTypes();
        }

        /// <summary>
        /// Gets the instance of the configuration type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        /// Resolved config type instance
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown if cannot retrieve configuration for type because 
        /// it is does not have the YamlConfiguration attribute defined
        /// </exception>
        public T Resolve 
        {
            get
            {
                var attribute = ConfigTypes.FirstOrDefault(t => t.Type == typeof(T));
                if (attribute == null)
                {
                    throw new InvalidOperationException($@"Cannot retrieve configuration for type '{typeof(T).Name}',
                                                        as it is does not have the YamlConfiguration attribute defined");
                }
                return LoadConfig(attribute.Attribute.ConfigurationFileName);
            }
        }

        /// <summary>
        /// Loads the configuration.
        /// </summary>
        /// <typeparam name="T">Configuration type</typeparam>
        /// <param name="configPath">The configuration path.</param>
        /// <returns>Instance of Config type</returns>
        private static T LoadConfig(string configPath)
        {
            var deserializer = new Deserializer(namingConvention: new NullNamingConvention(), ignoreUnmatched: true);

            using (TextReader reader = File.OpenText(configPath))
            {
                return deserializer.Deserialize<T>(reader);
            }
        }
    }
}
