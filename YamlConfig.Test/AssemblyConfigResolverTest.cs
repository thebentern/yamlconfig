using FluentAssertions;

using NUnit.Framework;

using YamlConfig.Core;

namespace YamlConfig.Test
{
    public class AsssemblyConfigResolverTest
    {
        [Test]
        public void Gets_All_Defined_Config_Types_In_Assembly()
        {
            var types = AssemblyConfigResolver.GetTypes();

            // These are the config type defined in our fixture
            types.Should().Contain(t => t.Type == typeof(AppConfig));
            types.Should().Contain(t => t.Type == typeof(DefaultConfig));
        }
    }
}
