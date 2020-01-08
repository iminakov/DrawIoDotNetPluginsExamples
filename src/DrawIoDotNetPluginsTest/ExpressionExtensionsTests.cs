using BaseDrawIoPlugin.Extensions;
using NUnit.Framework;

namespace DrawIoDotNetPluginsTest
{
    [TestFixture]
    public class ExpressionExtensionsTests
    {
        private interface TestContract
        {
            void OpenFile();
        }

        [Test]
        public void AsyncInteropServiceCanGetInterfaceMethodByReflectionTest()
        {
            var result = ExpressionExtensions.GetMethodName<TestContract>(c => c.OpenFile);

            Assert.AreEqual("OpenFile", result);
        }
    }
}