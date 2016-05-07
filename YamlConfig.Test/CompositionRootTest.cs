using SimpleInjector;

using YamlConfig.Core;

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
        //[Test]
        //public void Registers_Config_Provider()
        //{
            
        //    WeakReference reference = null;
        //    new Action(() =>
        //    {
        //        var compositionRoot = new ExtendedCompositionRoot();
        //        compositionRoot.Container.Verify(VerificationOption.VerifyAndDiagnose);

        //        reference = new WeakReference(compositionRoot, true);
        //    })();

        //    // Service should have gone out of scope about now, 
        //    // so the garbage collector can clean it up
        //    GC.Collect();
        //    GC.WaitForPendingFinalizers();

        //    Assert.IsNull(reference.Target);
        //}
    }
}
