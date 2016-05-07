using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace YamlConfig.Core
{
    /// <summary>
    /// Bootstrapper for loading the configuration
    /// </summary>
    /// <typeparam name="T">Configuration type</typeparam>
    public sealed class ConfigProvider<T> : IConfigProvider<T>
    {
        // ReSharper disable once StaticMemberInGenericType
        private static readonly IEnumerable<ConfigType> ConfigTypes;

        /// <summary>
        /// Initializes the <see cref="ConfigProvider{T}"/> class.
        /// </summary>
        /// <remarks>
        /// Static constructor is defined to reflect on 
        /// configuration types defined in the assembly
        /// </remarks>
        static ConfigProvider()
        {
            ConfigTypes = AssemblyConfigResolver.GetTypes();
        }

        /// <summary>
        /// Gets the configuration instance for the specified type.
        /// </summary>
        /// <value>
        /// The resolve.
        /// </value>
        public T Resolve => Config.Value;

        /// <summary>
        /// Lazy loads the config from 
        /// </summary>
        private static readonly Lazy<T> Config = new Lazy<T>(LoadConfig);

        /// <summary>
        /// Loads the configuration.
        /// </summary>
        /// <returns>Instance of Config type</returns>
        private static T LoadConfig()
        {
            var deserializer = new Deserializer(namingConvention: new NullNamingConvention(), ignoreUnmatched: true);

            using (TextReader reader = File.OpenText(GetConfigPath()))
            {
                return deserializer.Deserialize<T>(reader);
            }
        }

        /// <summary>
        /// Gets the configuration path.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown if cannot retrieve Yaml configuration for type
        /// </exception>
        private static string GetConfigPath()
        {
            var configType = ConfigTypes.FirstOrDefault(t => t.Type == typeof(T));
            if (configType == null)
            {
                throw new InvalidOperationException($@"Cannot retrieve Yaml configuration for type '{typeof(T).Name}'.
                                                        Please ensure that the YamlConfiguration attribute defined");
            }
            return configType.Attribute.ConfigurationFileName;
        }
    }
}
