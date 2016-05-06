using System.Linq;

using FluentAssertions;

using NUnit.Framework;

namespace YamlConfig.Test
{
    public class YamlConfigurationAttributeTest
    {
        [Test]
        public void File_Defaults_To_ConfigYml()
        {
            var types = AssemblyConfigResolver.GetTypes();
            var instance = types.FirstOrDefault(t => t.Type == typeof(AppConfig));

            instance.Attribute.ConfigurationFileName.Should().Be("Config.yml");
        }
    }
}
