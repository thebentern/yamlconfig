using NUnit.Framework;

namespace YamlConfig.Test
{
    using FluentAssertions;

    public class ConfigProviderTest
    {
        [Test]
        public void Retrieves_Config_From_Default_File()
        {
            var composition = new CompositionRoot();
            var defaultConfig = composition.Config<AppConfig>();

            defaultConfig.MuhString.Should().Be("Derp");
            defaultConfig.MuhFavoriteNumber.Should().Be(7);
            defaultConfig.MuhListOfThings.Should().Contain(new[] { "Cats", "Dogs", "Burds" });
        }

        [Test]
        public void Retrieves_Config_From_File_Defined_In_Attribute()
        {
            var composition = new CompositionRoot();
            var differentFileConfig = composition.Config<DifferentFileConfig>();
        }
    }
}
