using FluentAssertions;

using NUnit.Framework;
using SimpleInjector;
using System.Linq;

namespace YamlConfig.Test
{
    public class ExtendedCompositionRoot : CompositionRoot
    {
        public ExtendedCompositionRoot()
            : base()
        {
            
        }

        public new Container Container => base.Container;
    }

    public class CompositionRootTest
    {
        [Test]
        public void Registers_Config_Provider()
        {
            var compositionRoot = new ExtendedCompositionRoot();
            compositionRoot.Container.Verify(VerificationOption.VerifyAndDiagnose);

            //var instances = compositionRoot.Container.GetAllInstances(typeof(IConfigProvider<>));
            // Should be a singleton instance
            //instances.Count().Should().Be(1);
        }
    }
}
