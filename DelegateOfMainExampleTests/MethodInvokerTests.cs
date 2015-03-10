namespace DelegateOfMainExampleTests
{
    using DelegateOfMainExample;
    using DelegateOfMainExample.MethodInvokers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MethodInvokerTests
    {
        private MainMethodInvoker mainMethodInvoker;

        [TestInitialize]
        public void Setup()
        {
            if (VoidReturnMainEntry.HasRun) VoidReturnMainEntry.HasRun = false;
            if (IntegerReturnMainEntry.HasRun) IntegerReturnMainEntry.HasRun = false;
            mainMethodInvoker = new MainMethodInvoker();
        }

        #region MyImplementationTests
        [TestMethod]
        public void ShouldBeAbleToRunAVoidMainMethodWithStringArguments()
        {
            mainMethodInvoker.InvokeActionMethod(VoidReturnMainEntry.Main, new[] { "TestData" });
            AssertVoidReturnValueMainHasRun();
        }

        [TestMethod]
        public void ShouldBeAbleToRunAVoidMainWithoutArguments()
        {
            mainMethodInvoker.InvokeActionMethod(VoidReturnMainEntry.Main);
            AssertVoidReturnValueMainHasRun();
        }

        [TestMethod]
        public void ShouldBeAbleToRunAMainWithAnIntegerReturn()
        {
            var returnValue = mainMethodInvoker.InvokeFunctionMethod(IntegerReturnMainEntry.Main);
            AssertIntegerReturnValueMainHasRun();
            Assert.AreEqual(0, returnValue);
        }

        [TestMethod]
        public void ShouldBeAbleToRunMainWithAnIntegerReturnAndStringArguments()
        {
            var returnValue = mainMethodInvoker.InvokeFunctionMethod(IntegerReturnMainEntry.Main, new []{"TestData"});
            AssertIntegerReturnValueMainHasRun();
            Assert.AreEqual(0, returnValue);
        }
        #endregion

        #region AlternativeImplementationTests

        [TestMethod]
        public void ShouldBeAbleToRunAVoidMainWithoutArguments_Alternative()
        {
            mainMethodInvoker.InvokeMethod(VoidReturnMainEntry.Main);
            AssertVoidReturnValueMainHasRun();
        }

        [TestMethod]
        public void ShouldBeAbleToRunAVoidMainMethodWithStringArguments_Alternative()
        {
            mainMethodInvoker.InvokeMethod(VoidReturnMainEntry.Main, new[] {"TestData"});
            AssertVoidReturnValueMainHasRun();
        }

        [TestMethod]
        public void ShouldBeAbleToRunMainWithAnIntegerReturnAndStringArguments_Alternative()
        {
            var returnValue = mainMethodInvoker.InvokeMethod<int>(IntegerReturnMainEntry.Main, new[] { "TestData" });
            AssertIntegerReturnValueMainHasRun();
            Assert.AreEqual(0, returnValue);
        }

        [TestMethod]
        public void ShouldBeAbleToRunMainWithAnIntegerReturnAndStringArguments_OutAlternative()
        {
            int returnValue;
            mainMethodInvoker.InvokeMethod(IntegerReturnMainEntry.Main, new[] { "TestData" }, out returnValue);
            AssertIntegerReturnValueMainHasRun();
            Assert.AreEqual(0, returnValue);
        }

        [TestMethod]
        public void ShouldBeAbleToRunAMainWithAnIntegerReturn_Alternative()
        {
            var returnValue = mainMethodInvoker.InvokeMethod<int>(IntegerReturnMainEntry.Main);
            AssertIntegerReturnValueMainHasRun();
            Assert.AreEqual(0, returnValue);
        }

        [TestMethod]
        public void ShouldBeAbleToRunAMainWithAnIntegerReturn_OutAlternative()
        {
            int returnValue;
            mainMethodInvoker.InvokeMethod(IntegerReturnMainEntry.Main, out returnValue);
            AssertIntegerReturnValueMainHasRun();
            Assert.AreEqual(0, returnValue);
        }
        #endregion

        #region PrivateHelpers

        private void AssertVoidReturnValueMainHasRun()
        {
            Assert.IsTrue(VoidReturnMainEntry.HasRun);
        }

        private void AssertIntegerReturnValueMainHasRun()
        {
            Assert.IsTrue(IntegerReturnMainEntry.HasRun);
        }
        #endregion
    }
}
