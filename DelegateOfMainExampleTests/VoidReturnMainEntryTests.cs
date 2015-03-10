namespace DelegateOfMainExampleTests
{
    using System;
    using DelegateOfMainExample;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class VoidReturnMainEntryTests
    {
        [TestInitialize]
        public void Setup()
        {
            if (VoidReturnMainEntry.HasRun) VoidReturnMainEntry.HasRun = false;
        }

        [TestMethod]
        public void ShouldBeAbleToInvokeMainEntryWithNoArgs()
        {
            MethodInvoker(VoidReturnMainEntry.Main);
            Assert.IsTrue(VoidReturnMainEntry.HasRun);
        }

        [TestMethod]
        public void ShouldInvokeMainWithNullArgs()
        {
            MethodInvoker(VoidReturnMainEntry.Main, null);
            Assert.IsTrue(VoidReturnMainEntry.HasRun);
        }

        [TestMethod]
        public void ShouldInvokeMainWithHydratedArgs()
        {
            MethodInvoker(VoidReturnMainEntry.Main, new[]
                {
                    "Some Test Data", 
                    "Additional Test Data"
                });
            Assert.IsTrue(VoidReturnMainEntry.HasRun);
        }

        [TestMethod]
        public void ShouldInvokeMainWithAnEmptyStringArray()
        {
            MethodInvoker(VoidReturnMainEntry.Main, new string[0]);
            Assert.IsTrue(VoidReturnMainEntry.HasRun);
        }

        private void MethodInvoker(Action<String[]> methodToInvoke, params string[] args)
        {
            methodToInvoke(args);
        }
    }
}
