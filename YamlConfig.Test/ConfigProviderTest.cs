using System;
using System.IO;

using FluentAssertions;

using NUnit.Framework;

using YamlConfig.Core;

namespace YamlConfig.Test
{ 
    public class ConfigProviderTest
    {
        [SetUp]
        public void Init()
        {
            // Tests fail locally in test runner if we don't set the execution directory
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
        }

        [Test]
        public void Retrieves_And_Deserializes_Config_From_Default_File()
        {
            IConfigProvider<AppConfig> configProvider = new ConfigProvider<AppConfig>();
            var config = configProvider.Resolve;

            config.MuhString.Should().Be("Derp");
            config.MuhFavoriteNumber.Should().Be(7);
            config.MuhListOfThings.Should().Contain(new[] { "Cats", "Dogs", "Burds" });

            config.MuhComplexType.Derp.Should().Be("Thing");
            config.MuhComplexType.Derp2.Should().Be(10);
        }

        [Test]
        public void Throws_An_Exception_When_Attempting_To_Resolve_An_Unregistered_Type()
        {
            Assert.Throws<InvalidOperationException>(() => { var thing = new ConfigProvider<TextReader>().Resolve; });
        }

        [Test]
        public void Throws_An_IO_Exception_When_Attempting_To_Resolve_Type_With_Invalid_Config_Path()
        {
            Assert.Throws<InvalidOperationException>(() => { var thing = new ConfigProvider<TextReader>().Resolve; });
        }
    }
}
