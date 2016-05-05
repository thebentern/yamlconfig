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
        private static readonly IEnumerable<ConfigurationType> ConfigurationTypes;

        /// <summary>
        /// Initializes the <see cref="ConfigProvider{T}"/> class.
        /// </summary>
        static ConfigProvider()
        {
            ConfigurationTypes = ConfigurationTypesResolver.GetTypes();
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
                var attribute = ConfigurationTypes.FirstOrDefault(t => t.Type == typeof(T));
                if (attribute == null)
                {
                    throw new InvalidOperationException($@"Cannot retrieve configuration for type '{typeof(T).Name}',
                                                        as it is does not have the YamlConfiguration attribute defined");
                }
                return LoadConfiguration<T>(attribute.Attribute.ConfigurationFileName);
            }
        }

        /// <summary>
        /// Loads the configuration.
        /// </summary>
        /// <typeparam name="T">Configuration type</typeparam>
        /// <param name="configPath">The configuration path.</param>
        /// <returns></returns>
        private static T LoadConfiguration<T>(string configPath)
        {
            var deserializer = new Deserializer(namingConvention: new NullNamingConvention(), ignoreUnmatched: true);

            using (TextReader reader = File.OpenText(configPath))
            {
                return deserializer.Deserialize<T>(reader);
            }
        }
    }
}
