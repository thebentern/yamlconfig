using FluentAssertions;

using NUnit.Framework;

namespace YamlConfig.Test
{
    public class AsssemblyConfigResolverTest
    {
        [Test]
        public void Gets_All_Marked_Up_Config_Types_In_Assembly()
        {
            var types = AssemblyConfigResolver.GetTypes();

            // These two are defined in our fixtures
            types.Should().Contain(t => t.Type == typeof(AppConfig));
            types.Should().Contain(t => t.Type == typeof(DifferentFileConfig));
        }
    }
}
