using System;

namespace YamlConfig
{
    /// <summary>
    /// Container for Configuration type reference and its corresponding Attribute reference
    /// </summary>
    public class ConfigType
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public Type Type { get; set; }

        /// <summary>
        /// Gets or sets the attribute.
        /// </summary>
        /// <value>
        /// The attribute.
        /// </value>
        public YamlConfigAttribute Attribute { get; set; }
    }
}
