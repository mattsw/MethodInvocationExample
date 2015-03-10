namespace DelegateOfMainExampleTests
{
    using System;
    using DelegateOfMainExample;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IntegerReturnMainEntryTests
    {
        [TestInitialize]
        public void Setup()
        {
            if (IntegerReturnMainEntry.HasRun) IntegerReturnMainEntry.HasRun = false;
        }
        [TestMethod]
        public void ShouldBeAbleToInvokeMainEntryWithNoArgsAndReturnAnInteger()
        {
            MethodInvoker(IntegerReturnMainEntry.Main);
            Assert.IsTrue(IntegerReturnMainEntry.HasRun);
        }

        [TestMethod]
        public void ShouldInvokeMainWithNullArgsAndReturnAnInteger()
        {
            MethodInvoker(IntegerReturnMainEntry.Main, null);
            Assert.IsTrue(IntegerReturnMainEntry.HasRun);
        }

        [TestMethod]
        public void ShouldInvokeMainWithHydratedArgsAndReturnAnInteger()
        {
            MethodInvoker(IntegerReturnMainEntry.Main, new[]
                {
                    "Some Test Data", 
                    "Additional Test Data"
                });
            Assert.IsTrue(IntegerReturnMainEntry.HasRun);
        }

        [TestMethod]
        public void ShouldInvokeMainWithAnEmptyStringArrayAndReturnAnInteger()
        {
            MethodInvoker(IntegerReturnMainEntry.Main, new string[0]);
            Assert.IsTrue(IntegerReturnMainEntry.HasRun);
        }

        private void MethodInvoker(Func<string[], int> methodToInvoke, params string[] args)
        {
            var returnValue = methodToInvoke(args);
            Assert.AreEqual(returnValue, 0);
        }
    }
}
