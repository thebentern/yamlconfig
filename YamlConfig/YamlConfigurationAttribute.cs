using System;

namespace YamlConfig
{
    /// <summary>
    /// Configuration attribute for denoting the strongly typed configuration
    /// </summary>
    public sealed class YamlConfigurationAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YamlConfigurationAttribute"/> class.
        /// </summary>
        /// <param name="configurationFileName">Name of the configuration file.</param>
        /// <remarks>
        /// Configuration file defaults to Config.yml
        /// </remarks>
        public YamlConfigurationAttribute(string configurationFileName = null)
        {
            this.ConfigurationFileName = configurationFileName ?? "Config.yml";
        }

        /// <summary>
        /// Gets the path of the configuration file.
        /// </summary>
        /// <value>
        /// The name of the configuration file.
        /// </value>
        public string ConfigurationFileName { get; private set; }
    }
}
